using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = new Player(GetComponent<Rigidbody2D>());
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Vector3 currPos = transform.position;
            transform.position = player.Move(currPos);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision);
    }
}
