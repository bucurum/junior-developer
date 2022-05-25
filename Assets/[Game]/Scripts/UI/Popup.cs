using UnityEngine;
using DG.Tweening;
using TMPro;

public class Popup : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text;
    private bool isActive = false;

    private void Awake()
    {
        transform.localScale = Vector3.zero;
        gameObject.SetActive(false);

        GameManager.Instance.showPopupEvent.AddListener(Show);
        GameManager.Instance.hidePopupEvent.AddListener(Hide);
    }

    public void ActiveSmooth(bool isActive, float duration = 0.25f)
    {
        this.isActive = isActive;

        if (isActive)
        {
            gameObject.SetActive(true);
            transform.DOScale(1f, duration).SetEase(Ease.InCubic);
        }
        else
        {
            transform.DOScale(0f, duration).SetEase(Ease.InCubic).OnComplete(() => gameObject.SetActive(false));
        }
    }

    private void Show(string popupText)
    {
        if (!isActive)
        {
            text.text = popupText;
            ActiveSmooth(true);
        }
    }

    private void Hide()
    {
        if (isActive)
        {
            ActiveSmooth(false, 0.12f);
        }
    }
}
