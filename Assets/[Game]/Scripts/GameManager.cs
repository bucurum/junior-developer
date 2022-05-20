using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameActive;
    public bool IsGameActive => isGameActive;

    [HideInInspector] public UnityEvent<bool> onGameOver = new UnityEvent<bool>();
    [HideInInspector] public UnityEvent<string> showPopupEvent = new UnityEvent<string>();
    [HideInInspector] public UnityEvent hidePopupEvent = new UnityEvent();

    public static GameManager Instance { get; private set; }
    private int levelCount;

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

        isGameActive = true;

        // Load all levels to an array.
        GameObject[] levels = Resources.LoadAll<GameObject>("Levels");

        // Set total level count.
        levelCount = levels.Length;

        // Instantiate level.
        Instantiate(levels[DataManager.Instance.Level - 1]);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void EndGame(bool success)
    {
        isGameActive = false;

        if (success)
        {
            LevelUp();
        }

        Invoke(nameof(LoadScene), 2f);
        
        onGameOver?.Invoke(success);
    }

    private void LevelUp()
    {
        int newLevel = DataManager.Instance.Level + 1;

        if (newLevel > levelCount)
        {
            newLevel = 1;
        }

        DataManager.Instance.SetLevel(newLevel);
    }
}
