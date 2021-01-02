using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMoving : Wave
{
    private Vector3 targetPosition;

    void Start()
    {
        Spawn();
    }

    void Spawn()
    {
        foreach (Transform child in transform)
        {
            GameObject enemy = child.gameObject;
            print("Spawning: " + enemy);
        }
    }
}
