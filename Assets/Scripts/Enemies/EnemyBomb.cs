using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBomb : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector3 dest;
    private float speed;
    public float damage;

    void Start()
    {
        speed = 2f;
        damage = 10f;

        dest = Game.Player.transform.position;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = (dest - transform.position).normalized * speed;
    }

    void Update()
    {
        // float step = speed * Time.deltaTime;
        // transform.position = Vector3.MoveTowards(transform.position, dest, step);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // print("hit enemy " + col.gameObject);
            Destroy(gameObject);
            return;
        }

        if (col.gameObject.tag == "BTop")
        {
            Destroy(gameObject);
            return;
        }
    }
}
