using System.Collections;
using UnityEngine;

public class Flicker : MonoBehaviour
{
    float _interval = 0.5f;
    float _time = 0;
    bool _isFlickering;
    public GameObject recordingSymbol;

    void Update()
    {
        _time += Time.deltaTime;

        if (_time > _interval && !_isFlickering)
        {
            StartCoroutine(FlashImage());
        }
    }

    IEnumerator FlashImage()
    {
        _isFlickering = true;
        recordingSymbol.SetActive(false);
        yield return new WaitForSecondsRealtime(0.5f);
        recordingSymbol.SetActive(true);
        _isFlickering = false;
        _time = 0;
    }
}
