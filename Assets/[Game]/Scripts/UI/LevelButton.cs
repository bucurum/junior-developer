using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour
{
    public Button button;
    public int buttonIndex;
    private bool isClicked = false;

    private void Awake()
    {
        button.onClick.AddListener(() => {
            if (isClicked)
            {
                return;
            }
            isClicked = true;
            DataManager.Instance.SetLevel(buttonIndex + 1);
            SceneManager.LoadScene(0);
        });
    }
}
