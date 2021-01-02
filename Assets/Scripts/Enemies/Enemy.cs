using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    private Rigidbody2D rb;
    private float speed;

    // HealthBar
    public GameObject HealthBar;
    public Image HealthBarFill;
    public Vector3 Offset;

    void Start()
    {
        maxHealth = 10;
        currentHealth = maxHealth;
        speed = 1f;
        rb = GetComponent<Rigidbody2D>();
        HealthBar.SetActive(true);
        HealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Offset);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    void Update()
    {
        rb.velocity = transform.up * -speed;

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
        if (col.tag == "BTop")
        {
            return;
        }

        if (col.tag == "BBottom")
        {
            Destroy(gameObject);
        }

        // Add Collider condition
        currentHealth -= Game.currRadiation * 10f;
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
