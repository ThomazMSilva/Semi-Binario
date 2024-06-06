using UnityEngine;
using UnityEngine.SceneManagement;

public class MudaCena : MonoBehaviour
{
    public void LoadarCena(string nomeCena)

    {
        SceneManager.LoadScene(nomeCena);
    }

    public void FecharJogo()

    {
        Application.Quit();
        Debug.Log("Fechou");
    }
}