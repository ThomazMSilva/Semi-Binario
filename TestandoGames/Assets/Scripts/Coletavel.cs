using UnityEngine;
using UnityEngine.Events;

public class Coletavel : MonoBehaviour
{
    [SerializeField] UnityEvent OnCollected;
    [SerializeField] private AudioSource pegarItem; 

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            OnCollected?.Invoke();
            pegarItem.Play();
        }
    }
    
    public void PistaColetada()
    {
        print(gameObject.name + "chamou");
        LevelManager.instance.AddCollected();
        ContadorPecas.instance.AumentarPecas();
    }
}
