using UnityEngine;
using UnityEngine.Events;

public class DoSomethingOnDisable : MonoBehaviour
{
    public UnityEvent OnDisableAction;

    private void OnDisable()
    {
        OnDisableAction?.Invoke();
    }
}
