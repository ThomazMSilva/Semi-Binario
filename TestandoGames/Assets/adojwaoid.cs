using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class adojwaoid : MonoBehaviour
{
    public UnityEvent OnA;

    private void OnDisable()
    {
        OnA?.Invoke();
    }
}
