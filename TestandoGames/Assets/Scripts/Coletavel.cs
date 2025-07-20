using UnityEngine;
using UnityEngine.Events;

public class Coletavel : MonoBehaviour
{
    [SerializeField] private string inputAxis = "Interact";
    [SerializeField] UnityEvent OnCollected;
    [SerializeField] private AudioSource pegarItem;
    [SerializeField] private GameObject inputRequirementDisplay;
    [SerializeField] private string fallbackPath = "Prefabs/RequirementDisplay";
    private Coroutine inputBufferRoutine;

    private void Start()
    {
        if (inputRequirementDisplay == null)
        {
            var prefab = Resources.Load<GameObject>(fallbackPath);
            if (prefab != null) inputRequirementDisplay = Instantiate(prefab);
            var ownYOffset = inputRequirementDisplay.GetComponent<SpriteRenderer>().bounds.extents.y;
            var parentYOffset = GetComponent<BoxCollider2D>().bounds.extents.y;
            var yOffset = ownYOffset + parentYOffset;
            inputRequirementDisplay.transform.position = transform.position + Vector3.up * yOffset;
            inputRequirementDisplay.transform.SetParent(transform, true);
            inputRequirementDisplay.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inputRequirementDisplay.SetActive(true);
            inputBufferRoutine ??= StartCoroutine(WaitForInput());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inputRequirementDisplay.SetActive(false);
            if (inputBufferRoutine != null)
            {
                StopCoroutine(inputBufferRoutine);
                inputBufferRoutine = null;
            }
        }
    }

    private System.Collections.IEnumerator WaitForInput()
    {
        Debug.Log("Esperndo pelo inpujt");
        yield return new WaitUntil(() => Input.GetAxisRaw(inputAxis) != 0);
        Debug.Log("Deu inpujt");
        OnCollected?.Invoke();
        Debug.Log("cjhamou collelcted");
        if (pegarItem != null) pegarItem.Play();
        inputBufferRoutine = null;
    }

    public void PistaColetada()
    {
        print(gameObject.name + "chamou");
        LevelManager.instance.AddCollected();
        ContadorPecas.instance.AumentarPecas();
    }
}
