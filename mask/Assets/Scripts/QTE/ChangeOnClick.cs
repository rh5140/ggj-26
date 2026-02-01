using UnityEngine;
using UnityEngine.UI;

public class ChangeOnClick : Clickable
{
    public Image swapImage;
    public Sprite newImage;

    public override void UpdateOnClick()
    {
        minigame.DepleteHP();
        VisualChangeOnClick();
    }

    protected override void VisualChangeOnClick()
    {
        swapImage.sprite = newImage;
    }
}
