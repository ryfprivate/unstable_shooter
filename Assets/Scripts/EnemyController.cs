using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Enemy enemy;
    // Start is called before the first frame update
    void Start()
    {
        enemy = new Enemy(GetComponent<Rigidbody2D>());
    }

    // Update is called once per frame
    void Update()
    {

    }
}
