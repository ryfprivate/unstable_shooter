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
        GameEvents.current.onSelectMutation += Reset;
        Name.text = mutation.name;
        Level.text = mutation.level.ToString();

        print(mutation.name);
        print(mutation.level);
    }

    public void Select()
    {
        GameEvents.current.SelectMutation();
        GetComponent<Image>().color = new Color(0, 0, 0, 0.3f);
    }

    void Reset()
    {
        // Resetting colors
        GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
    }
}
