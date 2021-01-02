using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static int roundLength = 20;
    public static float waveTime = 10f;
    public static float currRadiation;
    public static float maxRadiation;

    void Start()
    {
        GameEvents.current.StartRound();
    }

    void Update()
    {

    }
}
