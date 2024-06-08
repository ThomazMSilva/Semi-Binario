using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderVolume : MonoBehaviour
{
    [SerializeField] Slider barraDeVolume; 
    [SerializeField] private GameObject menuOpcoes; 

    public void MudarVolume()

    {
        AudioListener.volume = barraDeVolume.value; 
        DontDestroyOnLoad(menuOpcoes); 
    }
}
