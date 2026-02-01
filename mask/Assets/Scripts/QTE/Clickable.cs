using UnityEngine;

public class Clickable : MonoBehaviour
{
    public Minigame minigame;
    public AudioClip sfx;

    public virtual void UpdateOnClick()
    {
        minigame.DepleteHP();
        VisualChangeOnClick();
    }

    protected virtual void VisualChangeOnClick()
    {
        AudioManager.Instance.PlaySound(sfx);
        Destroy(gameObject);
        return;
    }
}
