using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int roundLength = 3;
    public static float waveTime = 5f;

    void Start()
    {
        GameEvents.current.StartRound();
    }

    void Update()
    {

    }
}
