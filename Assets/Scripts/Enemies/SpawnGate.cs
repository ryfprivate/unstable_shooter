using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    public Round round;
    private Queue<GameObject> waveQueue;

    void Start()
    {
        GameEvents.current.onStartRound += InitializeRound;
        waveQueue = new Queue<GameObject>();
    }

    void InitializeRound()
    {
        GameObject[] prefabs = round.prefabsEasy;
        for (int i = 0; i < Game.roundLength; i++)
        {
            int index = Random.Range(0, prefabs.Length);
            waveQueue.Enqueue(prefabs[index]);
        }
        print("Loaded " + Game.roundLength + " waves");
        StartCoroutine(SpawnNewWave(5f));
    }

    IEnumerator SpawnNewWave(float waveTime)
    {
        if (waveQueue.Count == 0)
        {
            Debug.Log("no more levels");
            yield break;
        }

        GameObject prefab = waveQueue.Dequeue();
        Debug.LogFormat("Spawned {0}", prefab.name);
        GameObject obj = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        yield return new WaitForSeconds(waveTime);
        StartCoroutine(SpawnNewWave(5f));
    }
}
