using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    private float speed;
    void Start()
    {
        speed = 5;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Boundary") {
            // Debug.LogFormat("hit enemy");
            Destroy(gameObject);
            return;
        }
    }
}
