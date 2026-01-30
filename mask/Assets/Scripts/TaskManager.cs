using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public PlayerStatus status;
    public GameObject task;
    public float spawnInterval = 3f;
    public float multiplier = 1;
    float _currTime = 0f;
    float _totalTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Update()
    {
        _totalTime += Time.deltaTime;
        _currTime += Time.deltaTime;

        if (_currTime > spawnInterval)
        {
            SpawnTask();
            _currTime = 0;
        }

        if (_totalTime > spawnInterval * multiplier)
        {
            spawnInterval -= 0.5f;
            multiplier++;
            _totalTime = 0;
        }
    }

    void SpawnTask()
    {
        Instantiate(task, transform);
    }

    public void DepletePlayerStatus(int amount)
    {
        status.DepleteStatus(amount);
    }
}
