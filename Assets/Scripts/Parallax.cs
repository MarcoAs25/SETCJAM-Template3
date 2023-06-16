using UnityEngine;
//Classe responsavel por aplicar o efeito de parallax no background e ground
public class Parallax : MonoBehaviour
{
    private Material materialGameObject;
    [SerializeField]
    private float velocity = 5f;
    void Start()
    {
        materialGameObject = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (!GameManager.Instance.IsStarted)
            return;
        materialGameObject.mainTextureOffset = new Vector2(materialGameObject.mainTextureOffset.x + velocity * Time.deltaTime, 0f);
        
    }
}
