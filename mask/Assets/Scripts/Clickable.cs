using UnityEngine;

public class Clickable : MonoBehaviour
{
    public Minigame minigame;

    public void UpdateOnClick()
    {
        minigame.DepleteHP();
        VisualChangeOnClick();
    }

    protected virtual void VisualChangeOnClick()
    {
        Destroy(gameObject);
        return;
    }
}
