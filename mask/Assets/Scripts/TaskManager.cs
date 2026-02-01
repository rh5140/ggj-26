using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public PlayerStatus status;
    public GameObject[] tasks;
    public float spawnInterval = 2f;
    public float multiplier = 3;
    float _currTime = 0f;
    float _totalTime;
    float threshold;

    // void StartGame()
    // {
    //     SpawnTask();
    // }

    void Update()
    {
        _totalTime += Time.deltaTime;
        _currTime += Time.deltaTime;

        if (_currTime > spawnInterval)
        {
            int tasksCount = transform.childCount;
            if (tasksCount > 8)
            {
                threshold = 0.1f;
            }
            else if (tasksCount > 4)
            {
                threshold = 0.5f;
            }
            else if (tasksCount > 1)
            {
                threshold = 0.75f;
            }
            else
            {
                threshold = 1;
            }
            
            float spawnChance = Random.Range(0,1);
            if (threshold >= spawnChance)
                SpawnTask();
            _currTime = 0;
        }

        if (_totalTime > spawnInterval * multiplier)
        {
            spawnInterval -= 0.5f;
            multiplier *= 3;
            _totalTime = 0;
        }
    }

    void SpawnTask()
    {
        int idx = Random.Range(0,tasks.Length);
        GameObject newTask = Instantiate(tasks[idx], transform);
        newTask.transform.SetSiblingIndex(newTask.transform.GetSiblingIndex() - 2);
        HighlightTopItem();
    }

    public void HighlightTopItem()
    {
        // if (transform.childCount > 0)
        // {
        //     transform.GetChild(0).localScale = new Vector3(1f,1f,1f);
        // }
    }

    public void DepletePlayerStatus(int amount)
    {
        status.DepleteStatus(amount);
    }
}
