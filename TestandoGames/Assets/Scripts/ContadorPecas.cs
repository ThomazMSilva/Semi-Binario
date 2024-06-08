using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 

public class ContadorPecas : MonoBehaviour
{
    public static ContadorPecas instance; 

    public TMP_Text textoPecas;

    void Awake()

    {
        instance = this; 
    }

    void Start()

    {
        textoPecas.text = "Peças Coletadas: " + LevelManager.instance.GetCollected() + "/6";
    }

    public void AumentarPecas ()
    {
        textoPecas.text = "Peças Coletadas: " + LevelManager.instance.GetCollected() + "/6";
    }

}
