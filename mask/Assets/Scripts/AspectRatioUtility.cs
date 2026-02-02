using UnityEngine;

public class AspectRatioUtility : MonoBehaviour
{
    void Start()
    {
        Adjust();
    }

    public void Adjust()
    {
        // Target aspect ratio (16:9)
        float targetAspect = 16.0f / 9.0f;

        // Current window aspect ratio
        float windowAspect = (float)Screen.width / (float)Screen.height;

        // Scale height based on aspect ratio difference
        float scaleHeight = windowAspect / targetAspect;

        Camera camera = GetComponent<Camera>();

        if (scaleHeight < 1.0f)
        {
            // Window is taller than 16:9 (like 16:10)
            // Add black bars on top and bottom
            Rect rect = camera.rect;

            rect.width = 1.0f;
            rect.height = scaleHeight;
            rect.x = 0;
            rect.y = (1.0f - scaleHeight) / 2.0f;

            camera.rect = rect;
        }
        else
        {
            // Window is wider than 16:9 (like 21:9)
            // Add black bars on left and right
            float scaleWidth = 1.0f / scaleHeight;

            Rect rect = camera.rect;

            rect.width = scaleWidth;
            rect.height = 1.0f;
            rect.x = (1.0f - scaleWidth) / 2.0f;
            rect.y = 0;

            camera.rect = rect;
        }
    }
}