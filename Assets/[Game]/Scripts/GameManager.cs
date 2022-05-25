using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int levelCount;

    private bool isGameActive;
    public bool IsGameActive => isGameActive;

    [HideInInspector] public UnityEvent<bool> onGameOver = new UnityEvent<bool>();
    [HideInInspector] public UnityEvent<string> showPopupEvent = new UnityEvent<string>();
    [HideInInspector] public UnityEvent hidePopupEvent = new UnityEvent();

    public static GameManager Instance { get; private set; }

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

        // Instantiate level.
        Instantiate(Resources.Load<GameObject>("Levels/Level-" + DataManager.Instance.Level));
    }

    public void ResetGame()
    {
        DataManager.Instance.SetLevel(1);
        LoadScene();
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LoadLevelGalleryScene()
    {
        SceneManager.LoadScene(1);
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
