using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Task : MonoBehaviour
{
    public string description;
    public float duration = 0.2f;
    public int damage;
    public TaskManager taskManager;
    
    public Image colorBlock; // TEMPORARY
    public Color maxColor;
    public Color midColor;
    public Color minColor;

    float _currTime = 0f; // BAD NAMING...
    
    [SerializeField] TextMeshProUGUI _description; 
    [SerializeField] GameObject _minigame;
    

    void Awake()
    {
        taskManager = GetComponentInParent<TaskManager>();
        _description.text = description;
    }

    void Update()
    {
        _currTime += Time.deltaTime;
        if (_currTime > duration / 2) colorBlock.color = midColor;
        if (_currTime > duration * 3 / 4) colorBlock.color = maxColor;
        colorBlock.fillAmount = 1 - _currTime/duration;
        if (_currTime >= duration)
        {
            taskManager.DepletePlayerStatus(damage);
            Destroy(gameObject);
        }
    }

    public void StartMinigame()
    {
        _description.text = "ACTIVE!!";
        Minigame minigame = Instantiate(_minigame, GameObject.Find("GameplayCanvas").transform).GetComponent<Minigame>();
        minigame.task = this;
    }

    void OnDestroy()
    {
        taskManager.HighlightTopItem();
    }
}
