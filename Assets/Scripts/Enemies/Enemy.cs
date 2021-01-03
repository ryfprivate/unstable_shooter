using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public GameObject Explosion;
    public GameObject Bomb;
    public float maxHealth;
    public float currentHealth;

    // HealthBar
    public GameObject HealthBar;
    public Image HealthBarFill;
    public Vector3 Offset;

    void Start()
    {
        maxHealth = 30;
        currentHealth = maxHealth;
        HealthBar.SetActive(true);
        HealthBar.transform.position = Camera.main.WorldToScreenPoint(transform.position + Offset);
        StartCoroutine(Fire());
    }

    void Update()
    {
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

    IEnumerator Fire()
    {
        float randValue = Random.value;
        if (randValue < .1f)
        {
            GameObject instance = Instantiate(Bomb, transform.position, transform.rotation);
        }
        // print("laser " + instance);
        yield return new WaitForSeconds(1f);
        StartCoroutine(Fire());
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
        if (col.tag == "PLaser")
        {
            currentHealth -= Game.currRadiation * 10f;
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
                GameObject explosion = Instantiate(Explosion, transform.position, transform.rotation, transform.parent);
            }
        }
    }
}
