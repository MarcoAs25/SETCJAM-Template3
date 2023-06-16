using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

//Classe responsavel por Gerenciar o jogo (carregamento de cena, quando o jogo comeca, fim de jogo)
//(Classe com padrao Singleton)
public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public UnityEvent<bool> onStartChange;
    private bool isStarted;
    private bool gameOver;

    public bool IsStarted
    {
        get => isStarted;
        set
        {
            if(isStarted != value)
            {
                isStarted = value;
                onStartChange?.Invoke(isStarted);
            }
        }
    }

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
        isStarted = false;
        gameOver = false;
    }
    private void LateUpdate()
    {
        if (IsStarted || gameOver)
            return;
        if (Input.GetKeyUp(KeyCode.Space))
        {
            IsStarted = true;
        }
    }
    public void GameOver()
    {
        gameOver = true;
        IsStarted = false;
        Invoke("LoadScene", 2);
    }
    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
