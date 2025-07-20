using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzleVisual : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    public static PuzzleVisual Instance { get; private set; }

    [SerializeField] private GameObject puzzleUI;
    [SerializeField] private RectTransform[] puzzlePieces;
    [SerializeField] private RectTransform[] correctPositions;
    [SerializeField] private float snapDistance = 50f;

    private bool[] piecesLocked;
    private int currentDraggingIndex = -1;
    private Vector2[] initialPositions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        piecesLocked = new bool[puzzlePieces.Length];
        initialPositions = new Vector2[puzzlePieces.Length];

        // Store initial positions
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            initialPositions[i] = puzzlePieces[i].anchoredPosition;
        }

        HidePuzzleUI();
    }

    public void ShowPuzzleUI()
    {
        puzzleUI.SetActive(true);
        ResetPuzzle();
    }

    public void HidePuzzleUI()
    {
        puzzleUI.SetActive(false);
    }

    private void ResetPuzzle()
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            puzzlePieces[i].anchoredPosition = initialPositions[i];
            piecesLocked[i] = false;
            puzzlePieces[i].GetComponent<Image>().raycastTarget = true;
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        for (int i = 0; i < puzzlePieces.Length; i++)
        {
            if (RectTransformUtility.RectangleContainsScreenPoint(puzzlePieces[i], eventData.position) && !piecesLocked[i])
            {
                currentDraggingIndex = i;
                puzzlePieces[i].SetAsLastSibling(); // Bring to front
                break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (currentDraggingIndex >= 0 && !piecesLocked[currentDraggingIndex])
        {
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                puzzlePieces[currentDraggingIndex].parent as RectTransform,
                eventData.position,
                eventData.pressEventCamera,
                out Vector2 localPoint);

            puzzlePieces[currentDraggingIndex].localPosition = localPoint;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (currentDraggingIndex >= 0 && !piecesLocked[currentDraggingIndex])
        {
            // Check if piece is near its correct position
            float distance = Vector2.Distance(
                puzzlePieces[currentDraggingIndex].anchoredPosition,
                correctPositions[currentDraggingIndex].anchoredPosition);

            if (distance <= snapDistance)
            {
                // Snap to correct position
                puzzlePieces[currentDraggingIndex].anchoredPosition = correctPositions[currentDraggingIndex].anchoredPosition;
                piecesLocked[currentDraggingIndex] = true;
                puzzlePieces[currentDraggingIndex].GetComponent<Image>().raycastTarget = false;

                // Notify manager if it exists
                if (PuzzleManager.Instance != null)
                {
                    PuzzleManager.Instance.PiecePlacedCorrectly();
                }
            }
        }

        currentDraggingIndex = -1;
    }
    
    public void OnPointerDown(PointerEventData eventData)
{
    Debug.Log("Pointer down detected on: " + eventData.pointerCurrentRaycast.gameObject.name);
}
}