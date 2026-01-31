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
    public Color minColor;
    Gradient gradient;
    GradientColorKey[] colors;

    float _currTime = 0f; // BAD NAMING...
    
    [SerializeField] TextMeshProUGUI _description; 
    [SerializeField] GameObject _minigame;
    

    void Awake()
    {
        taskManager = GetComponentInParent<TaskManager>();
        _description.text = description;
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
        _currTime += Time.deltaTime;
        colorBlock.color = gradient.Evaluate(_currTime/duration);
        if (_currTime >= duration)
        {
            taskManager.DepletePlayerStatus(damage);
            taskManager.RemoveFromTaskList(gameObject);
            Destroy(gameObject);
        }
    }

    public void StartMinigame()
    {
        _description.text = "ACTIVE!!";
        Minigame minigame = Instantiate(_minigame, GameObject.Find("GameplayCanvas").transform).GetComponent<Minigame>();
        minigame.task = this;
    }
}
