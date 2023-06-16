using UnityEngine;
//Classe responsavel por tocar sons na cena
public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance { get; private set; }
    [SerializeField]
    private AudioSource playJump;
    [SerializeField]
    private AudioSource playScore;
    [SerializeField]
    private AudioSource playHit;
    [SerializeField]
    private AudioSource playSlide;
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
    public void PlayScore()
    {
        playScore.Play();
    }
    public void PlayJump()
    {
        playJump.Play();
    }
    public void PlayHit()
    {
        playHit.Play();
    }
    public void PlaySlide()
    {
        playSlide.Play();
    }
}
