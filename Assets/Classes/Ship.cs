using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ship
{
    public float currHealth;
    public Ship(Rigidbody2D rb) {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
