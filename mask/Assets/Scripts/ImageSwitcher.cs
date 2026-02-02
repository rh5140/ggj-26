using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Image targetImage;
    public Sprite[] sprites;
    public float switchInterval = 0.5f;
    
    private int currentIndex = 0;
    private float timer = 0f;
    
    void Update()
    {
        timer += Time.unscaledDeltaTime;
        
        if (timer >= switchInterval)
        {
            currentIndex = (currentIndex + 1) % sprites.Length;
            targetImage.sprite = sprites[currentIndex];
            timer = 0f;
        }
    }
}