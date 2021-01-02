using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHealth = 100;
    public float currentHealth = 100;
    private Rigidbody2D rb;
    private float speed;
    private bool isMoving;

    // HealthBar
    public GameObject HealthBar;
    public Image HealthBarFill;
    public Vector3 Offset;

    void Start()
    {
        isMoving = false;
        speed = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        HealthBar.SetActive(true);
        HealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Offset);
    }

    public void Move() {
        isMoving = true;
    }

    void Update()
    {
        if (isMoving) {
            rb.velocity = transform.up * -speed;
        }

        Slider Slider = HealthBar.GetComponent<Slider>();
        Slider.maxValue = maxHealth;
        Slider.value = currentHealth;

        HealthBarFill.color = new Color(0, 1f, 0f);
        if (Slider.value <= maxHealth / 2)
        {
            HealthBarFill.color = new Color(1f, 0.6f, 0);
        }
        if (Slider.value <= 2 * maxHealth / 10)
        {
            HealthBarFill.color = new Color(1f, 0, 0);
        }
        // Move HealthBar with enemy
        HealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Offset);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "BTop") {
            return;
        }

        if (col.tag == "BBottom") {
            Destroy(gameObject);
        }

        // Add Collider condition
        currentHealth -= 10;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
