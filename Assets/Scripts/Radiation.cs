using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radiation : MonoBehaviour
{
    private float speed;
    private Vector3 dest;

    void Start()
    {
        speed = 4f;
        dest = new Vector3(-2.5f, 3.75f, 0);
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, dest, step);
        if (Vector3.Distance(dest, transform.position) < 0.1)
        {
            Game.currRadiation *= Game.radiationConstant;
            if (Game.currRadiation > Game.maxRadiation)
            {
                Game.currRadiation = Game.maxRadiation;
            }
            Destroy(gameObject);
        }
    }
}
