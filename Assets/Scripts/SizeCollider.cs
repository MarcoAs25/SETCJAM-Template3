using UnityEngine;
//Classe responsavel por diminuir o colisor do player no momento do slide e retornar ao seu tamanho original ao final do slide
public class SizeCollider : StateMachineBehaviour
{
    [SerializeField]
    private bool isStarting;
    [SerializeField]
    private bool isjumping;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isStarting)
        {
            CapsuleCollider2D collider = animator.gameObject.GetComponent<CapsuleCollider2D>();
            collider.offset = new Vector2(collider.offset.x, -1.11f);
            collider.size = new Vector2(collider.size.x, 3.06f);
            animator.gameObject.transform.position = new Vector3(animator.gameObject.transform.position.x, -3.311f, animator.gameObject.transform.position.z);
        }
        else
        {
            CapsuleCollider2D collider = animator.gameObject.GetComponent<CapsuleCollider2D>();
            collider.offset = new Vector2(collider.offset.x, -0.67f);
            collider.size = new Vector2(collider.size.x, 6.3f);
            if(!isjumping)
                animator.gameObject.transform.position = new Vector3(animator.gameObject.transform.position.x, -3.1f, animator.gameObject.transform.position.z);
        }
        
    }

    
}
