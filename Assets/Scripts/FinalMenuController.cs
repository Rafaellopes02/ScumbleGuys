using UnityEngine;
using TMPro;

public class FinalMenuController : MonoBehaviour
{
    public TMP_Text timerText;
    public AudioSource victoryAudio;
    public Animator characterAnimator; // Referência ao Animator do boneco

    void Start()
    {
         victoryAudio.Play();
        // Atualiza o tempo final no texto
        string tempoFinal = PlayerPrefs.GetString("FinalTime", "00:00");

        if (timerText != null)
        {
            timerText.text = tempoFinal;
        }
        else
        {
            Debug.LogError("Campo 'timerText' não atribuído no Inspector.");
        }

        // Toca a animação de vitória no boneco
        if (characterAnimator != null)
        {
            characterAnimator.Play("FG_Emote_slowclap_A"); // Substitui "Victory" pelo nome exato da animação no Animator
        }
        else
        {
            Debug.LogError("Campo 'characterAnimator' não atribuído no Inspector.");
        }
    }
}
