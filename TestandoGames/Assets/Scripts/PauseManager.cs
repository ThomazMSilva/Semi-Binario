using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public void PararJogo()
    {
        Time.timeScale = 0; 
    }

    public void VoltarJogo()
    {
        Time.timeScale = 1; 
    }
}
