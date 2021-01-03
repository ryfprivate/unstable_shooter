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
        GameEvents.current.onSelectMutation += Display;
    }

    public void Upgrade()
    {
        Game.selectedMutation.LevelUp();
    }

    void Display()
    {
        Desc.text = Game.selectedMutation.mutation.description;
        int level = Game.selectedMutation.mutation.level;
        Cost.text = "-  " + Game.selectedMutation.mutation.costs[level].ToString();
    }
}
