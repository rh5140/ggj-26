using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public float recoveryAmount = 1; 
    public float recoveryInterval = 1;
    public GameObject gameOverScreen;
    public TextMeshProUGUI valueDisplay; // TEMPORARY
    public Image colorBlock; // TEMPORARY
    public Color maxColor;
    public Color minColor;

    float _maxValue = 100;
    float _currValue;
    float _time;

    Gradient gradient;
    GradientColorKey[] colors;

    public GameObject bathroom;
    public float bathroomDuration = 5f;
    public float bathroomShortenedInterval = 0.1f;

    void Start()
    {
        _currValue = _maxValue;
        _time = 0f;
        // ref: https://docs.unity3d.com/6000.3/Documentation/ScriptReference/Gradient.html
        gradient = new Gradient();
        colors = new GradientColorKey[2];
        colors[0] = new GradientColorKey(minColor, 0.0f);
        colors[1] = new GradientColorKey(maxColor, 1.0f);
        GradientAlphaKey[] alphas = new GradientAlphaKey[2];
        alphas[0] = new GradientAlphaKey(1.0f, 0.0f);
        alphas[1] = new GradientAlphaKey(1.0f, 1.0f);
        gradient.SetKeys(colors, alphas);
    }

    void Update()
    {
        _time += Time.deltaTime;

        if (_time > recoveryInterval)
        {
            _currValue = Mathf.Min(_maxValue, _currValue + recoveryAmount);
            _time = 0;
            UpdateVisual();
        }

        if (_currValue == 0)
        {
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
    }

    void UpdateVisual()
    {
        valueDisplay.text = _currValue + "%";
        float interval = _currValue / _maxValue;
        colorBlock.color = gradient.Evaluate(interval);
    }

    public void DepleteStatus(int amount)
    {
        _currValue = Mathf.Max(0, _currValue - amount);
        UpdateVisual();
    }

    public void BathroomBreak()
    {
        StartCoroutine(RunBreak());
    }

    IEnumerator RunBreak()
    {
        bathroom.SetActive(true);
        recoveryInterval = bathroomShortenedInterval;
        yield return new WaitForSecondsRealtime(bathroomDuration);
        recoveryInterval = 1f;
        bathroom.SetActive(false);
    }
}
