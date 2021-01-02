﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Slider HealthBar;
    public Slider RadiationBar;

    public GameObject PrefabLaser;
    private Rigidbody2D rb;
    public float currHealth;
    public float maxHealth;
    public float currRadiation;
    public float maxRadiation;
    private Vector3 mousePos;
    private float speed;
    private float maxX;
    private float maxY;

    void Awake()
    {
        GameEvents.current.onGamePlay += Test;
    }

    void Start()
    {
        maxHealth = 100f;
        currHealth = maxHealth;
        maxRadiation = 1000f;
        currRadiation = 0;
        speed = 0.05f;
        maxX = 2.5f;
        maxY = 4.5f;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("ShootLaser", 1.0f, 0.3f);

        // UI
        HealthBar.maxValue = maxHealth;
        HealthBar.value = currHealth;
        RadiationBar.maxValue = maxRadiation;
        RadiationBar.value = currRadiation;
    }

    void Test()
    {
        Debug.Log("Game STart");
    }

    void Update()
    {
        // Update health
        HealthBar.value = currHealth;
        // Update radiation
        RadiationBar.value = currRadiation;

        if (Input.GetMouseButton(0))
        {
            Vector3 currPos = transform.position;
            transform.position = Move(currPos);
        }
    }

    void ShootLaser()
    {
        GameObject instance = Instantiate(PrefabLaser, transform.position, transform.rotation);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        TakeDamage(10);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        TakeDamage(0.5f);
    }

    public void TakeDamage(float percentage)
    {
        currHealth -= percentage / 100 * maxHealth;
        if (currHealth < 0)
        {
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
