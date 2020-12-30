using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject laser;

    void Start()
    {
        Game.player = new Player(GetComponent<Rigidbody2D>());
        InvokeRepeating("ShootLaser", 1.0f, 0.3f);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currPos = transform.position;
            transform.position = Game.player.Move(currPos);
        }
    }

    void ShootLaser()
    {
        GameObject instance = Instantiate(laser, transform.position, transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Game.player.TakeDamage(10);
    }

    void OnCollisionStay2D(Collision2D collision) 
    {
        Game.player.TakeDamage(0.5f);
    }
}
