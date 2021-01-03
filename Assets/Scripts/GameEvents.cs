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
        print("in start round trigger");
        if (onStartRound != null)
        { 
            onStartRound();
        }
    }

    public event Action onEndRound;
    public void EndRound()
    {
        if (onEndRound != null)
        {
            onEndRound();
        }
    }
}
