using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider healthBar;
    void Start()
    {
        Debug.LogFormat("Player health: {0}", Game.player.currHealth);
        healthBar.wholeNumbers = true;
        healthBar.minValue = 0;
    }

    void Update()
    {

        healthBar.maxValue = Game.player.maxHealth;
        healthBar.value = Game.player.currHealth;
    }

}
