using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public PlayerStatus status;
    public GameObject[] tasks;
    public float spawnInterval = 3f;
    public float multiplier = 1;
    float _currTime = 0f;
    float _totalTime;


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
        int idx = Random.Range(0,tasks.Length);
        Instantiate(tasks[idx], transform);
        HighlightTopItem();
    }

    public void HighlightTopItem()
    {
        if (transform.childCount > 0)
        {
            transform.GetChild(0).localScale = new Vector3(1.2f,1.2f,1.2f);
        }
    }

    public void DepletePlayerStatus(int amount)
    {
        status.DepleteStatus(amount);
    }
}
