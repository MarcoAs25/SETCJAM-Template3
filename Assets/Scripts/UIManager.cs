using UnityEngine;
using UnityEngine.UI;
//Classe responsavel por mostrar informacoes de pontuacao na tela
public class UIManager : MonoBehaviour
{
    private Text textScore;
    void Start()
    {
        textScore = GetComponentInChildren<Text>();
        textScore.text = "0";
        ScoreManager.Instance.onScoreChange.AddListener(UpdateUIScore);
        textScore.color = Color.black;
    }

    void UpdateUIScore(int score, int maxScore)
    {
        if(score > maxScore)
        {
            textScore.color = Color.red;
        }
        textScore.text = score.ToString();
    }
}
