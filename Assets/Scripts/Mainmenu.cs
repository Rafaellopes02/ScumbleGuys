using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Chamar quando o botão Jogar for clicado
    public void Jogar()
    {
        SceneManager.LoadScene("SampleScene"); // Substitui pelo nome correto da tua cena de jogo
    }

    // Chamar quando o botão Sair for clicado
    public void Sair()
    {
        Debug.Log("A sair do jogo...");
        Application.Quit();
    }
}
