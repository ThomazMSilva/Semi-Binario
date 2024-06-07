using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeScene : MonoBehaviour
{
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
        if (method != null) Invoke(method,0);

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
