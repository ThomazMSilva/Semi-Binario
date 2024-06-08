using UnityEngine;
using UnityEngine.Events; 

//[[FilePath("SomeSubFolder/StateFile.foo", FilePathAttribute.Location.PreferencesFolder)]]

public class LevelManager : MonoBehaviour //ScriptableSingleton<MySingleton>
{
    private static int
        level_s = 0,
        collected_s = 0;
    private static readonly int[] maxCollected = new int[] { 5, 5, 6 };
    public UnityEvent PassouDeNivel; 
    public static LevelManager instance; 

    void Awake ()
    {
        instance = this; 
        DontDestroyOnLoad(this.gameObject); 
    }
    
    public void NextLevel()
    {
        Debug.Log("Passou de nivel!");
        level_s++;
        collected_s = 0;
        PassouDeNivel?.Invoke();
    }
    
    public int GetCurrentLevel(){ return level_s; }

    public void AddCollected() 
    {
        if (collected_s >= maxCollected[level_s])
        {
            NextLevel();
            return;
        }
        Debug.Log("Coletou!");
        collected_s++;
    }

    public int GetCollected() {  return collected_s; }

}
