using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    public float maxHealth;
    private Vector3 mousePos;
    private float speed;
    private float maxX;
    private float maxY;

    public Player(Rigidbody2D rb): base(rb)
    {
        maxHealth = 100f;
        currHealth = maxHealth;
        speed = 0.05f;
        maxX = 2.5f;
        maxY = 4.5f;
    }

    public void TakeDamage(float percentage) {
        currHealth -= percentage/100 * maxHealth;
        if (currHealth < 0) {
            currHealth = 0;
        }
    }

    public Vector3 Move(Vector3 currPos)
    {
        mousePos = Input.mousePosition;

        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        float newX = mousePos.x;
        float newY = mousePos.y;
        float newZ = mousePos.z;
        if (mousePos.x > maxX)
        {
            newX = maxX;
        }
        if (mousePos.x < -maxX)
        {
            newX = -maxX;
        }
        if (mousePos.y > maxY)
        {
            newY = maxY;
        }
        if (mousePos.y < -maxY)
        {
            newY = -maxY;
        }
        mousePos = new Vector3(newX, newY, newZ);

        return Vector2.Lerp(currPos, mousePos, speed);
    }
}
