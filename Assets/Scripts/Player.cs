using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    private float radiationConstant = 1.05f;

    public Slider HealthBar;
    public TextMeshProUGUI HealthBarLabel;
    public Slider RadiationBar;
    public TextMeshProUGUI RadiationBarLabel;

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
    private float minY;

    private float fireRate;
    private float decayRate;

    void Start()
    {
        fireRate = 0.3f;
        // Decay every second
        decayRate = 1f;
        maxHealth = 100f;
        currHealth = maxHealth;
        maxRadiation = 2f;
        currRadiation = 0.1f;
        speed = 0.05f;
        maxX = 2.5f;
        maxY = 3f;
        minY = -4.5f;
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("ShootLaser", 0, fireRate);
        InvokeRepeating("Decay", 0, decayRate);

        // UI
        HealthBar.maxValue = maxHealth;
        HealthBar.value = currHealth;
        HealthBarLabel.text = currHealth.ToString();
        RadiationBar.maxValue = maxRadiation;
        RadiationBar.value = currRadiation;
        RadiationBarLabel.text = currRadiation.ToString();
    }

    void Update()
    {
        // Update health
        HealthBar.value = currHealth;
        HealthBarLabel.text = currHealth.ToString();
        // Update radiation
        RadiationBar.value = currRadiation;
        RadiationBarLabel.text = currRadiation.ToString("F3");

        if (Input.GetMouseButton(0))
        {
            Vector3 currPos = transform.position;
            transform.position = Move(currPos);
        }
    }

    void Decay() {
        currRadiation *= radiationConstant;
        if (currRadiation > maxRadiation) {
            currRadiation = maxRadiation;
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
        if (mousePos.y < minY)
        {
            newY = minY;
        }
        mousePos = new Vector3(newX, newY, newZ);

        return Vector2.Lerp(currPos, mousePos, speed);
    }
}
