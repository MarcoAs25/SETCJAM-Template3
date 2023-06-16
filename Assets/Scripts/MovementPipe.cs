using UnityEngine;
//Classe responsavel por aplicar o efeito de movimento nos Obstaculos
public class MovementPipe : MonoBehaviour
{
    [SerializeField]
    private float velocity;
    [SerializeField]
    private float maxDistance;

    void Update()
    {
        if (!GameManager.Instance.IsStarted)
            return;
        transform.position = new Vector3(transform.position.x + velocity * Time.deltaTime, transform.position.y, transform.position.z);
        if(transform.position.x <= maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
