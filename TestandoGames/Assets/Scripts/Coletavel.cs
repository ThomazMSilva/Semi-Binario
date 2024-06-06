using UnityEngine;
using UnityEngine.Events;

public class Coletavel : MonoBehaviour
{
    [SerializeField] UnityEvent OnCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCollected?.Invoke();
        }
    }
}
