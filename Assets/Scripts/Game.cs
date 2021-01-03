using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    public static GameObject Player;
    public static int roundLength = 3;
    public static float waveTime = 10f;

    public static float radiationConstant = 1.05f;
    public static float growthRate;
    public static float currHealth;
    public static float maxHealth;
    public static float currRadiation;
    public static float maxRadiation;

    public static int shipLevel;

    public static MutationDisplay selectedMutation;
    public Mutation reactor;
    public Mutation ship;
    public Mutation weapons;

    void Start()
    {
        reactor.Reset();
        ship.Reset();
        weapons.Reset();

        UpdateStats();
        GameEvents.current.StartRound();
    }

    void Update()
    {
        UpdateStats();
    }

    public void NextRound() {
        GameEvents.current.StartRound();
    }

    void UpdateStats() {
        growthRate = reactor.upgrades[reactor.level];
        shipLevel = ship.level;
        maxHealth = ship.upgrades[ship.level];
        maxRadiation = weapons.upgrades[weapons.level];
    }
}
