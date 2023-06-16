using UnityEngine;
//Classe responsavel por spawnar obstaculos na cena
public class SpawnerManager : MonoBehaviour
{
    [SerializeField]
    private GameObject[] gmObstacle;
    private float timeElapsed;
    [SerializeField]
    private float timeSpawn;

    void Update()
    {
        if (!GameManager.Instance.IsStarted)
            return;
        timeElapsed += Time.deltaTime;
        if(timeElapsed > timeSpawn)
        {
            timeElapsed = 0f;
            Instantiate(gmObstacle[Random.Range(0, gmObstacle.Length)]);
        }
    }
}
