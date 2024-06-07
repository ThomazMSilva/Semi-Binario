using UnityEngine;

public static class LevelManager
{
    private static int
        level_s = 0,
        collected_s = 0;
    private static readonly int[] maxCollected = new int[] { 5, 5, 6 };

    public static void NextLevel()
    {
        Debug.Log("Passou de nivel!");
        level_s++;
        collected_s = 0;
    }
    
    public static int GetCurrentLevel(){ return level_s; }

    public static void AddCollected() 
    {
        if (collected_s >= maxCollected[level_s])
        {
            NextLevel();
            return;
        }
        Debug.Log("Coletou!");
        collected_s++;
    }

    public static int GetCollected() {  return collected_s; }

}
