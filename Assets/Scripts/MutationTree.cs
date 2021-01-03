using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MutationTree : MonoBehaviour
{
    public TextMeshProUGUI Desc;
    public TextMeshProUGUI Cost;

    void Start()
    {
    }

    void Update()
    {
        if (!Game.selectedMutation) return;
        Desc.text = Game.selectedMutation.mutation.description;
        int level = Game.selectedMutation.mutation.level;
        if (level == Game.selectedMutation.mutation.upgrades.Length - 1)
        {
            Cost.text = "";
        }
        else
        {
            Cost.text = "-  " + Game.selectedMutation.mutation.costs[level].ToString();
        }
    }

    public void Upgrade()
    {
        Game.selectedMutation.LevelUp();
    }
}
