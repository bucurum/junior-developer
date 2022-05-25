using UnityEngine;

public class DataManager : MonoBehaviour
{
    public int Level { get; private set; }

    public static DataManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            GetData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void GetData()
    {
        Level = PlayerPrefs.GetInt("level-data", 1);
    }

    public void SetLevel(int _level)
    {
        Level = _level;
        PlayerPrefs.SetInt("level-data", _level);
        PlayerPrefs.Save();
    }
}
