using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGate : MonoBehaviour
{
    public Round round;
    private Queue<GameObject> waveQueue;

    private IEnumerator cSpawn;

    void Awake() {
        waveQueue = new Queue<GameObject>();
        GameEvents.current.onStartRound += InitializeRound;
        GameEvents.current.onGameOver += Stop;
    }

    void InitializeRound()
    {
        print("SpawnGAte OnStartRound");
        GameObject[] prefabs = round.prefabsEasy;
        for (int i = 0; i < Game.roundLength; i++)
        {
            int index = Random.Range(0, prefabs.Length);
            waveQueue.Enqueue(prefabs[index]);
        }
        print("Loaded " + Game.roundLength + " waves");
        cSpawn = SpawnNewWave();
        StartCoroutine(cSpawn);
    }

    void Stop() {
        print("stopping");
        StopCoroutine(cSpawn);
        waveQueue = new Queue<GameObject>();
    }

    IEnumerator SpawnNewWave()
    {
        if (waveQueue.Count == 0)
        {
            Debug.Log("no more levels");
            // yield return new WaitForSeconds(Game.waveTime);
            GameEvents.current.EndRound();
            yield break;
        }

        GameObject prefab = waveQueue.Dequeue();
        Debug.LogFormat("Spawned {0}", prefab.name);
        GameObject obj = Instantiate(prefab, transform.position, transform.rotation) as GameObject;
        yield return new WaitForSeconds(Game.waveTime);
        StartCoroutine(SpawnNewWave());
    }
}
