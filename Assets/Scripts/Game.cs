using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static GameObject Player;
    public static int roundLength = 6;
    public static float waveTime = 10f;

    public static float radiationConstant = 1.05f;
    public static float growthRate;
    public static float currRadiation;
    public static float maxRadiation;

    public static MutationDisplay selectedMutation;

    void Start()
    {
        GameEvents.current.onSelectMutation += Display;
        GameEvents.current.StartRound();
    }

    void Update()
    {
        // print("player " + Player.transform.position);
    }

    void Display() {
        print("mutation: " + selectedMutation.name);
    }
}
