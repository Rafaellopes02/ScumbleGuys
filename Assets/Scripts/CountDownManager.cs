using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CountDownManager : MonoBehaviour
{
    public Image countdownImage;
    public Sprite[] countdownSprites; // [3, 2, 1, GO]
    public GameObject player;
    public TMP_Text timerText; 

    private float timer = 0f;
    private bool startCounting = false;
    private bool isCounting = false;

    void Start()
    {
        StartCoroutine(CountdownRoutine());
    }

    void Update()
    {
        if (startCounting && isCounting)
        {
            timer += Time.deltaTime;

            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    IEnumerator CountdownRoutine()
    {
        player.GetComponent<Player>().enabled = false;

        for (int i = 0; i < countdownSprites.Length; i++)
        {
            countdownImage.sprite = countdownSprites[i];
            countdownImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(1f);
        }

        countdownImage.gameObject.SetActive(false);
        player.GetComponent<Player>().enabled = true;


        // Iniciar o cronómetro
        startCounting = true;
        isCounting = true;
    }

    // Chama esta função para parar o temporizador (ex: no fim da corrida)
    public void PararTemporizador()
    {
        isCounting = false;
    }
}
