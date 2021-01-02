using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int roundLength = 3;

    void Start()
    {
        GameEvents.current.StartRound();
        GameEvents.current.SpawnWave();
    }

    void Update()
    {

    }
}
