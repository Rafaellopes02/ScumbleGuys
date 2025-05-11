using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishZone : MonoBehaviour
{
    public CountDownManager countDownManager;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            countDownManager.PararTemporizador();
            SceneManager.LoadScene("FinalMenu");
        }
    }

}
