using UnityEngine;
using UnityEngine.Events;
//Classe responsavel por gerenciar a pontuacao do jogo (maxScore e Score)
//(Classe com padrao Singleton)
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }
    [SerializeField]
    private int score;
    [SerializeField]
    private int maxScore;

    public UnityEvent<int, int> onScoreChange;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        score = 0;
        if (PlayerPrefs.HasKey("maxScore"))
        {
            maxScore = PlayerPrefs.GetInt("maxScore");
        }
        else
        {
            PlayerPrefs.SetInt("maxScore", 0);
            maxScore = 0;
        }
    }
    public void AddScore()
    {
        SoundManager.Instance.PlayScore();
        score++;
        if(score > maxScore)
        {
            maxScore = score;
            PlayerPrefs.SetInt("maxScore", maxScore);
        }
#if UNITY_EDITOR
        Debug.Log(score);
#endif
        onScoreChange?.Invoke(score, maxScore);
    }
}
