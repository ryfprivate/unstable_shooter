using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Enemy[] enemies;

    void Start()
    {
        enemies = new Enemy[3];
    }

    void Update()
    {

    }
}
