using UnityEngine;

public class LevelButtonController : MonoBehaviour
{
    [SerializeField] private LevelButton[] buttons;

    private void Awake()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].buttonIndex = i;

            // Set Level Text
            buttons[i].GetComponentInChildren<TMPro.TextMeshProUGUI>().text = "Level " + (i + 1);
        }
    }
}
