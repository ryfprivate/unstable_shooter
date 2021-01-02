using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static GameObject Player;
    public static int roundLength = 6;
    public static float waveTime = 10f;
    public static float currRadiation;
    public static float maxRadiation;

    void Start()
    {
        GameEvents.current.StartRound();
    }

    void Update()
    {
        // print("player " + Player.transform.position);
    }
}
