using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    public Round round;
    private Queue<GameObject> waveQueue;

    void Start()
    {
        waveQueue = new Queue<GameObject>();
        InitializeQueue();
        InvokeRepeating("SpawnNewWave", 2, 5);
    }

    void InitializeQueue()
    {
        GameObject[] prefabs = round.prefabsEasy;
        int index = Random.Range(0, prefabs.Length);
        waveQueue.Enqueue(prefabs[index]);
    }

    void OnTriggerEnter(Collider collider)
    {
    }

    void SpawnNewWave()
    {
        if (waveQueue.Count == 0)
        {
            Debug.Log("no more levels");
            return;
        }

        GameObject prefab = waveQueue.Dequeue();
        Debug.LogFormat("Spawned {0}", prefab.name);
        GameObject obj = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        InitializeQueue();
    }
}
