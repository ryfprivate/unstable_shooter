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
        print("in start round trigger" + onStartRound);
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

    public event Action onSelectMutation;
    public void SelectMutation()
    {
        if (onSelectMutation != null)
        {
            onSelectMutation();
        }
    }

    public event Action onGameOver;
    public void GameOver()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }
}
