using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class Dialogue : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private RectTransform baloonRectTransform;
    [TextArea, SerializeField] string[] texts;
    [SerializeField] TextMeshProUGUI TMPText;
    [SerializeField] float characterInterval;
    [SerializeField] bool hasBackground;
    int currentIndex;
    bool isTextFinished;
    public UnityEvent OnTextFinished;

    public void OnPointerClick(PointerEventData eventData)
    {
        StopAllCoroutines();

        if (!isTextFinished)
        {
            TMPText.text = (hasBackground ? "<font=\"LiberationSans SDF\"> <mark=#000000 padding=10,20,5,5>" : "") + texts[currentIndex];
            isTextFinished = true;
        }

        else
        {
            TMPText.text = "";

            if (currentIndex + 1 < texts.Length)
            {
                currentIndex++;
                StartCoroutine(InvocaTexto(texts[currentIndex]));
            }
            else
            {
                OnTextFinished?.Invoke();
            }

        }
    }

    private void OnEnable()
    {
        currentIndex = 0;
        StartCoroutine(InvocaTexto(texts[currentIndex]));
    }

    public IEnumerator InvocaTexto(string textoNovo)
    {
        isTextFinished = false;
        TMPText.text = hasBackground ? "<font=\"LiberationSans SDF\"> <mark=#000000 padding=10,20,5,5>" : "";
        WaitForSeconds intervalo = new(characterInterval);

        for (int i = 0; i < textoNovo.Length; i++)
        {
            TMPText.text += textoNovo[i];
            yield return intervalo;
        }
        isTextFinished = true;

        yield return null;
    }
}
