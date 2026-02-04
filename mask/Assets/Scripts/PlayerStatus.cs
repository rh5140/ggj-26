using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStatus : MonoBehaviour
{
    public float recoveryAmount = 1; 
    public float recoveryInterval = 1;
    public GameObject gameOverScreen;
    public TextMeshProUGUI valueDisplay; 
    float _maxValue = 100;
    float _currValue;
    float _time;


    public GameObject bathroom;
    public float bathroomDuration = 3f;
    public float bathroomShortenedInterval = 0.1f;

    bool _bathroomCooldown = false;
    public float bathroomCooldownTime = 5f;
    public RectTransform bathroomUI;
    public Image bathroomFill;
    public RectTransform bathroomTransition;

    public Image mask;
    public Sprite[] masks;

    public AudioClip bathroomAmbient;
    public AudioClip officeAmbient;

    public Color maxColor;
    public Color midColor;
    public Color minColor;
    public Image barFill;

    void Start()
    {
        _currValue = _maxValue;
        // Time.timeScale = 1;
    }

    public void StartGame()
    {
        _time = 0f;
        AudioManager.Instance.ChangeMusic(officeAmbient);
        StartCoroutine(ResetBathroomButton());
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
            foreach (Minigame mg in FindObjectsOfType<Minigame>())
            {
                Destroy(mg.gameObject);
            }
            Time.timeScale = 0;
            gameOverScreen.SetActive(true);
        }
    }

    void UpdateVisual()
    {
        if (_currValue > 90)
        {
            mask.sprite = masks[0];
        }
        else if (_currValue > 70)
        {
            mask.sprite = masks[1];
        }
        else if (_currValue > 50)
        {
            mask.sprite = masks[2];
        }
        else if (_currValue > 30)
        {
            mask.sprite = masks[3];
        }
        else if (_currValue > 10)
        {
            mask.sprite = masks[4];
        }
        else
        {
            mask.sprite = masks[5];
        }

        barFill.fillAmount = _currValue / _maxValue;
        valueDisplay.text = _currValue + "%";

        if (_currValue > 70)
        {
            barFill.color = maxColor;
        }
        else if (_currValue > 40)
        {
            barFill.color = midColor;
        }
        else
        {
            barFill.color = minColor;
        }
    }

    public void DepleteStatus(int amount)
    {
        _currValue = Mathf.Max(0, _currValue - amount);
        UpdateVisual();
    }

    public void BathroomBreak()
    {
        if (_bathroomCooldown) return;
        else StartCoroutine(RunBreak());
    }

    IEnumerator RunBreak()
    {
        StartCoroutine(TranslateVertically(bathroomTransition, new Vector2(0,1000), 1f));
        yield return new WaitForSecondsRealtime(0.5f);
        AudioManager.Instance.ChangeMusic(bathroomAmbient);
        bathroom.SetActive(true);
        _bathroomCooldown = true;
        recoveryInterval = bathroomShortenedInterval;
        float bathroomTime = 0;
        while (bathroomTime < bathroomDuration)
        {
            bathroomTime += Time.deltaTime;
            bathroomFill.fillAmount = bathroomTime/bathroomDuration;
            yield return null;
        }
        recoveryInterval = 1f;
        StartCoroutine(TranslateVertically(bathroomTransition, new Vector2(0,-1000), 1f));
        yield return new WaitForSecondsRealtime(0.5f);
        bathroom.SetActive(false);
        AudioManager.Instance.ChangeMusic(officeAmbient);
        StartCoroutine(ResetBathroomButton());
    }

    IEnumerator ResetBathroomButton()
    {
        StartCoroutine(TranslateVertically(bathroomUI, new Vector2(-586,-580), 0.4f));
        yield return new WaitForSecondsRealtime(bathroomCooldownTime);
        _bathroomCooldown = false;
        StartCoroutine(TranslateVertically(bathroomUI, new Vector2(-586,-333), 0.2f));
        yield return new WaitForSecondsRealtime(0.2f);
        bathroomFill.fillAmount = 0;
    }

    IEnumerator TranslateVertically(RectTransform ui, Vector2 newPosition, float duration)
    {
        Vector2 startPosition = ui.anchoredPosition;
        
        float translateTime = 0;
        while (translateTime < duration)
        {
            translateTime += Time.deltaTime;
            ui.anchoredPosition = Vector2.Lerp(startPosition, newPosition, translateTime / duration);
            yield return null;
        }
    }
}
