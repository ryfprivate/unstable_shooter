using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public GameObject[] enemies;
    void Start()
    {
        int numEnemies = transform.childCount;
        enemies = new GameObject[numEnemies];

        int index = 0;
        foreach (Transform child in transform)
        {
            // Rename object to match index and add to enemies array
            child.gameObject.name = index.ToString();
            enemies[index] = child.gameObject;
            index++;
        }
    }
}
