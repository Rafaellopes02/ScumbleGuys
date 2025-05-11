using UnityEngine;
using TMPro;

public class FinalMenuController : MonoBehaviour
{
    public TMP_Text tempoText;

    void Start()
    {
        string tempoFinal = PlayerPrefs.GetString("FinalTime", "00:00");
        tempoText.text = "Tempo: " + tempoFinal;
    }
}
