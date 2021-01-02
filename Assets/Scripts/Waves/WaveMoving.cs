using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMoving : Wave
{
    private float waveTime = 10f;
    private Vector3 targetPosition;

    void Start()
    {
        GameEvents.current.onSpawnWave += Spawn;
        // targetPosition = new Vector3(0, -6, 0);
        // StartCoroutine(MoveToPosition());
    }

    void Spawn()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = child.gameObject;
            print("Spawning: " + enemy);
            enemy.GetComponent<Enemy>().Move();
        }
    }

    public IEnumerator MoveToPosition()
    {
        Vector3 currentPosition = transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / waveTime;
            transform.position = Vector3.Lerp(currentPosition, targetPosition, t);
            yield return null;
        }
    }
}
