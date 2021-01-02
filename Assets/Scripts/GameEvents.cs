using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    void Awake()
    {
        current = this;
    }

    public event Action onStartRound;
    public void StartRound()
    {
        if (onStartRound != null)
        {
            onStartRound();
        }
    }

    public event Action onSpawnWave;
    public void SpawnWave()
    {
        if (onSpawnWave != null)
        {
            onSpawnWave();
        }
    }
}
