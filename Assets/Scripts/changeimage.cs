using UnityEngine;
using UnityEngine.UI;

public class ChangeImageOnClick : MonoBehaviour
{
    public Image imageToChange;
    public Sprite newSprite;
    public Sprite originalSprite;

    void Start()
    {
        imageToChange = GetComponent<Image>();
        originalSprite = imageToChange.sprite;
    }

    public void ChangeSprite()
    {
        if (imageToChange.sprite == newSprite)
        {
            imageToChange.sprite = originalSprite;
        }
        else
        {
            imageToChange.sprite = newSprite;
        }
    }
}