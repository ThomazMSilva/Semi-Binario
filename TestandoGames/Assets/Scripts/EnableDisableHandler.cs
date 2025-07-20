using UnityEngine;
using UnityEngine.Events;

public class EnableDisableHandler : MonoBehaviour
{
    public UnityEvent OnEnableAction;
    public UnityEvent OnDisableAction;

    private void OnEnable() => OnEnableAction?.Invoke();

    private void OnDisable() => OnDisableAction?.Invoke();
}
