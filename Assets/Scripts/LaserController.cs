using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour
{
    private Rigidbody2D rb;
    private float speed;
    void Start()
    {
        speed = 5;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.up * speed;
    }
}
