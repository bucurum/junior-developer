using UnityEngine;
using UnityEngine.UI;

public class UIBoxAppearance : MonoBehaviour
{
    public BoxColor color = BoxColor.Brown;
    public bool showIgnoreButton = false;

    [Space, Header("Box Colors")]
    public Color redColor;
    public Color greenColor;
    public Color purpleColor;
    public Color brownColor;

    [Space]
    [SerializeField] private GameObject ignoreIcon;
    [SerializeField] private Image boxImage;

    private void OnValidate()
    {
        if (ignoreIcon != null)
        {
            ignoreIcon.SetActive(showIgnoreButton);
        }

        if (boxImage != null)
        {
            switch (color)
            {
                case BoxColor.Red: boxImage.color = redColor; break;
                case BoxColor.Green: boxImage.color = greenColor; break;
                case BoxColor.Purple: boxImage.color = purpleColor; break;
                case BoxColor.Brown: boxImage.color = brownColor; break;
            }
        }
    }
}
