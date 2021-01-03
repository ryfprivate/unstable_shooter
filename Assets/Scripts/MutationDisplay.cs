using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MutationDisplay : MonoBehaviour
{
    public Mutation mutation;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Level;

    void Start()
    {
        GameEvents.current.onSelectMutation += Deselect;
        Name.text = mutation.name;
        Level.text = mutation.level.ToString();
        if (mutation.level == mutation.upgrades.Length)
        {
            Level.text = "-";
        }
    }

    void Update()
    {
        Name.text = mutation.name;
        Level.text = mutation.level.ToString();
        if (mutation.level == mutation.upgrades.Length)
        {
            Level.text = "-";
        }
    }

    public void Select()
    {
        Game.selectedMutation = this;
        GameEvents.current.SelectMutation();
        GetComponent<Image>().color = new Color(0, 0, 0, 0.3f);
    }

    public void LevelUp()
    {
        if (mutation.level == mutation.upgrades.Length) return;
        mutation.level += 1;
    }

    void Deselect()
    {
        // Resetting colors
        GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
    }
}
