using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public PlayerStatus status;
    public GameObject[] tasks;
    public float spawnInterval = 4f;
    public float multiplier = 5;
    float _currTime = 0f;
    float _totalTime;
    float threshold;
    float _gameTime = 0f;

    // void StartGame()
    // {
    //     SpawnTask();
    // }

    void Update()
    {
        _totalTime += Time.deltaTime;
        _currTime += Time.deltaTime;
        _gameTime += Time.deltaTime;

        if (_currTime > spawnInterval)
        {
            int tasksCount = transform.childCount;

            int maxTasks = GetMaxTasks();
            if (tasksCount >= maxTasks) return;

            if (tasksCount > 8)
            {
                threshold = 0.05f;
            }
            else if (tasksCount > 4)
            {
                threshold = 0.3f;
            }
            else if (tasksCount > 1)
            {
                threshold = 0.5f;
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
        // newTask.transform.SetSiblingIndex(1);
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
    int GetMaxTasks()
    {
        int minute = Mathf.FloorToInt(_gameTime / 60f);  // Use _gameTime instead

        switch (minute)
        {
            case 0: return 3;
            case 1: return 5;
            case 2: return 7;
            case 3: return 9;
            default: return 11;
        }
    }
}
