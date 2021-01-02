using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    void Start()
    {
        GameEvents.current.GamePlay();
        GameEvents.current.SpawnWave();
    }

    void Update()
    {

    }
}
