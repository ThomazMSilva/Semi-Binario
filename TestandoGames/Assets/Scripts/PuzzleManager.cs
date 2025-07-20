using UnityEngine;
using UnityEngine.SceneManagement;

public class PuzzleManager : MonoBehaviour
{
    public static PuzzleManager Instance { get; private set; }
    
    [SerializeField] private int totalPieces = 5;
    [SerializeField] private string nextSceneName;
    
    private int collectedPieces = 0;
    private int correctlyPlacedPieces = 0;
    private bool puzzleCompleted = false;

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
    }

    // Called when player collects a puzzle piece in the world
    public void CollectPiece()
    {
        collectedPieces++;
        
        if (collectedPieces >= totalPieces)
        {
            // All pieces collected, show puzzle UI
            PuzzleVisual.Instance.ShowPuzzleUI();
        }
    }

    // Called when a piece is placed in the correct position
    public void PiecePlacedCorrectly()
    {
        correctlyPlacedPieces++;
        
        if (correctlyPlacedPieces >= totalPieces && !puzzleCompleted)
        {
            puzzleCompleted = true;
            LoadNextScene();
        }
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(nextSceneName);
    }
}