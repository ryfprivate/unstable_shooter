using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Game : MonoBehaviour
{
    public GameObject GameOver;
    public TextMeshProUGUI Wave;

    public static GameObject Player;
    public static int roundLength = 3;
    public static float waveTime = 10f;
    public static int waveNum = 0;

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
        print("Game Start");
        GameEvents.current.onGameOver += EndGame;
        StartGame();
    }

    void Update()
    {
        UpdateStats();
        Wave.text = "Wave " + waveNum.ToString();
    }

    void Initialize() {
        waveNum = 0;
        roundLength = 3 + Mathf.RoundToInt(waveNum*0.2f);
        waveTime = 10f;

        radiationConstant = 1.05f;
        currHealth = maxHealth;
        currRadiation = 0.01f;
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

    void EndGame() {
        GameOver.SetActive(true);
    }

    void StartGame() {
        GameOver.SetActive(false);
        reactor.Reset();
        ship.Reset();
        weapons.Reset();

        UpdateStats();
        Initialize();
        GameEvents.current.StartRound();
    }

    public void Restart() {
        Scene scene = SceneManager.GetActiveScene(); SceneManager.LoadScene(scene.name);
    }
}
