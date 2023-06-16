using UnityEngine;

//Classe responsavel pelas acoes do player e detecao de colisao e etc
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private bool isGrounded = true;
    [SerializeField]
    private Transform posFoot;
    [SerializeField]
    private LayerMask lmGround;
    [SerializeField]
    private float footRadius = 0.3f;
    private Rigidbody2D rb2d;
    [SerializeField]
    private float velocityJump = 5f;
    private Animator anim;
    void Start()
    {
        posFoot = GetComponentsInChildren<Transform>()[1];
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        GameManager.Instance.onStartChange.AddListener(UpdateIsStarted);
    }
    private void UpdateIsStarted(bool value)
    {
        anim.SetBool("IsStarted", value);
    }

    void Update()
    {
        if (!GameManager.Instance.IsStarted)
            return;
        isGrounded = Physics2D.OverlapCircleAll(posFoot.position, footRadius, lmGround).Length != 0;
        anim.SetBool("IsGrounded", isGrounded);
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb2d.velocity = Vector2.up * velocityJump;
            SoundManager.Instance.PlayJump();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (isGrounded)
            {
                anim.SetTrigger("slide");
                SoundManager.Instance.PlaySlide();
            }
            else
            {
                rb2d.velocity = Vector2.down * velocityJump/2;
            }
            
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(posFoot.position, footRadius);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag.Equals("Obstacle"))
        {
            SoundManager.Instance.PlayHit();
            GameManager.Instance.GameOver();
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Score"))
        {
            SoundManager.Instance.PlayScore();
            ScoreManager.Instance.AddScore();
        }
    }
}
