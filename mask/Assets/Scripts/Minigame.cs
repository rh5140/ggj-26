using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum QTE
{
    Coffee
}

public class Minigame : MonoBehaviour
{
    public Task task;

    public int hp = 5;
    public int damageOverTime = 2;

    float _currTime = 0f;
    public float interval = 1f;

    public QTE qte;
    public Image swapImage;
    public Sprite finalImage;

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
            switch (qte)
            {
                case QTE.Coffee:
                    SwapImageThenDestroy();
                    break;
                default:
                    EndMinigame();
                    break;
            }
        }
        UpdateVisual();
    }

    void UpdateVisual()
    {
        //valueDisplay.text = "Clicks left: " + hp;
    }

    void SwapImageThenDestroy()
    {
        swapImage.sprite = finalImage;
        EndMinigame(0.4f);
    }

    void EndMinigame(float delay = 0)
    {
        Destroy(task.gameObject, delay);
        Destroy(gameObject, delay);
    }
}
