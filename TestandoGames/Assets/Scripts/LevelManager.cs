using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    private static int
        level_s = 0,
        collected_s = 0;
    private static readonly int[] maxCollected = new int[] { 5, 5, 5 };
    public UnityEvent PassouDeNivel; 
    public static LevelManager instance;

    void Awake ()
    {
        instance = this;
    }
    
    public void NextLevel()
    {
        level_s++;
        collected_s = 0;
        PassouDeNivel?.Invoke();
    }
    
    public void AvancaNivel()
    {
        switch (level_s)
        {
            case 1:
                print("Carregando cena 2");
                SceneManager.LoadSceneAsync("Cap 2");
                break;

            case 2:
                print("Carregando cena 3");
                SceneManager.LoadSceneAsync("Cap 3");
                break;

            default: print("N�o conseguiu carrgar cena"); break;
        }
    }
    public int GetCurrentLevel(){ return level_s; }

    public void AddCollected() 
    {

        collected_s++;
        print(collected_s + " / " + maxCollected[level_s]);
        if (collected_s >= maxCollected[level_s])
        {
            NextLevel();
            return;
        }
        Debug.Log("Coletou!");
    }

    public int GetCollected() {  return collected_s; }

    public IEnumerator TransicionaCena(Image transitionImage, float transitionTime, string method = null)
    {
        float
            timeMultiplier = 1 / transitionTime * .5f;

        Color
            originalColor = transitionImage.color,
            currentColor = originalColor;

        currentColor.a = 0;

        transitionImage.color = currentColor;

        transitionImage.gameObject.SetActive(true);

        //Fade In
        while (transitionImage.color.a < originalColor.a)
        {
            currentColor.a += originalColor.a * (Time.deltaTime * timeMultiplier);
            transitionImage.color = currentColor;

            yield return null;
        }

        //Faz coisas entre transicao
        if (method != null) Invoke(method, 0);

        //Fade Out
        while (transitionImage.color.a > 0)
        {
            currentColor.a -= originalColor.a * (Time.deltaTime * timeMultiplier);
            transitionImage.color = currentColor;

            yield return null;
        }

        transitionImage.gameObject.SetActive(false);
        yield return null;
    }
}
