using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Slider healthBar;
    public Image healthBarFill;
    void Start()
    {
        healthBar.wholeNumbers = true;
        healthBar.minValue = 0;
    }

    void Update()
    {
        float maxH = Game.player.maxHealth;
        healthBar.maxValue = maxH;
        healthBar.value = Game.player.currHealth;

        healthBarFill.color = new Color(0, 1f, 0f);
        if (healthBar.value <= maxH / 2)
        {
            healthBarFill.color = new Color(1f, 0.6f, 0);
        }
        if (healthBar.value <= maxH / 10)
        {
            healthBarFill.color = new Color(1f, 0, 0);
        }
    }

}
