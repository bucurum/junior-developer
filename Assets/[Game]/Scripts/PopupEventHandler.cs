using UnityEngine;

public class PopupEventHandler : MonoBehaviour
{
    [SerializeField] private string popupText;

    private void Start()
    {
        GameManager.Instance.showPopupEvent?.Invoke(popupText);
        enabled = false;
    }
}
