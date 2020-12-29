using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Ship
{
    private Vector3 mousePos;
    private float speed;
    private float maxX;
    private float maxY;

    public Player()
    {
        speed = 0.05f;
        maxX = 8;
        maxY = 4;
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
