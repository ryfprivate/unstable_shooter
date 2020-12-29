using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 mousePos;
    private float speed = 0.05f;
    private float maxX = 8;
    private float maxY = 4;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0)) {
            mousePos = Input.mousePosition;

            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            float newX = mousePos.x;
            float newY = mousePos.y;
            float newZ = mousePos.z;
            if (mousePos.x > maxX) {
                newX = maxX;
            }
            if (mousePos.x < -maxX) {
                newX = -maxX;
            }
            if (mousePos.y > maxY) {
                newY = maxY;
            }
            if (mousePos.y < -maxY) {
                newY = -maxY;
            }
            mousePos = new Vector3(newX, newY, newZ);

            transform.position = Vector2.Lerp(transform.position, mousePos, speed);
        }
    }
}
