using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    public float damage;

    void Start()
    {
        speed = 5;
        damage = 10f;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
        // Physics2D.IgnoreCollision(GetComponent<Collider2D>(), player.GetComponent<Collider2D>());
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            // print("hit enemy " + col.gameObject);
            Destroy(gameObject);
            return;
        }

        if (col.gameObject.tag == "BTop") {
            Destroy(gameObject);
            return;
        }
    }
}
