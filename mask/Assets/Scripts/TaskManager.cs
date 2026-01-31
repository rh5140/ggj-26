using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public PlayerStatus status;
    public GameObject[] tasks;
    public float spawnInterval = 3f;
    public float multiplier = 1;
    float _currTime = 0f;
    float _totalTime;
    List<GameObject> taskList;

    void Start()
    {
        taskList = new List<GameObject>();
    }

    void Update()
    {
        _totalTime += Time.deltaTime;
        _currTime += Time.deltaTime;
        if (taskList.Count > 0) taskList[0].transform.localScale = new Vector3(1.2f,1.2f,1.2f);

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
        int idx = Random.Range(0,tasks.Length);
        GameObject newTask = Instantiate(tasks[idx], transform);
        taskList.Add(newTask);
    }

    public void DepletePlayerStatus(int amount)
    {
        status.DepleteStatus(amount);
    }

    public void RemoveFromTaskList(GameObject finishedTask)
    {
        taskList.Remove(finishedTask);
    }
}
