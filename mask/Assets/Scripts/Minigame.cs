using TMPro;
using UnityEngine;

public class Minigame : MonoBehaviour
{
    public Task task;

    public int hp = 5;
    public int damageOverTime = 2;
    public TextMeshProUGUI valueDisplay;

    float _currTime = 0f;
    public float interval = 1f;

    void Awake()
    {
        UpdateVisual();
    }

    void Update()
    {
        // REALLY JANK
        _currTime += Time.deltaTime;
        if (_currTime > interval)
        {
            task.taskManager.DepletePlayerStatus(damageOverTime);
            _currTime = 0;
        }
        if (task == null) Destroy(gameObject);
    }

    public void DepleteHP()
    {
        hp--;
        if (hp == 0)
        {
            Destroy(task.gameObject);
            Destroy(gameObject);
        }
        UpdateVisual();
    }

    void UpdateVisual()
    {
        valueDisplay.text = "Clicks left: " + hp;
    }
}
