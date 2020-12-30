using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        Game.player = new Player(GetComponent<Rigidbody2D>());
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currPos = transform.position;
            transform.position = Game.player.Move(currPos);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
        Game.player.TakeDamage(10);
    }

    void OnCollisionStay2D(Collision2D collision) {
        Debug.Log(collision);
        Game.player.TakeDamage(0.5f);
    }
}
