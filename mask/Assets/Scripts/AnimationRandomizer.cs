using System.Collections;
using UnityEngine;

public class AnimationRandomizer : MonoBehaviour
{
    public GameObject[] speechBubbles;
    public float intervalMin = 10f;
    public float intervalMax = 30f;
    public float animDuration = 3f;
    float _interval = 10f;
    float _time = 0;
    bool _animationPlaying = false;

    void Update()
    {
        _time += Time.deltaTime;

        if (_time > _interval && !_animationPlaying)
        {
            StartCoroutine(PlayAnimation(animDuration));
        }
    }

    void ActivateAnimation()
    {
        int idx = Random.Range(0,2);
        if (idx == 0)
        {
            speechBubbles[0].SetActive(true);
        }
        else
        {
            speechBubbles[1].SetActive(true);
        }
    }

    IEnumerator PlayAnimation(float duration)
    {
        _animationPlaying = true;
        ActivateAnimation();
        yield return new WaitForSecondsRealtime(duration);
        speechBubbles[0].SetActive(false);
        speechBubbles[1].SetActive(false);
        _animationPlaying = false;
        _time = 0;
        _interval = Random.Range(intervalMin, intervalMax);
    }
}
