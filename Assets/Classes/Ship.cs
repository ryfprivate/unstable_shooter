using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public float currHealth;
    public Rigidbody2D rb;

    public Ship(Rigidbody2D rigidBody) {
        rb = rigidBody;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
