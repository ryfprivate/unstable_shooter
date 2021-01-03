using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public GameObject MutationTree;

    public Slider HealthBar;
    public TextMeshProUGUI HealthBarLabel;
    public Slider RadiationBar;
    public TextMeshProUGUI RadiationBarLabel;

    public TextMeshProUGUI Timer;

    public GameObject PrefabLaser;
    private Rigidbody2D rb;
    public float currHealth;
    public float maxHealth;
    private Vector3 mousePos;
    private float speed;
    private float maxX;
    private float maxY;
    private float minY;

    private float fireRate;
    private float decayRate;
    private int seconds;

    // Coroutines
    private IEnumerator cDecay;
    private IEnumerator cShoot;
    private IEnumerator cTimer;

    private bool inPlay;

    void Start()
    {
        GameEvents.current.onEndRound += PauseMode;
        Game.Player = gameObject;

        seconds = 0;
        fireRate = 0.3f;
        // Decay every second
        decayRate = 1f;

        maxHealth = 100f;
        currHealth = maxHealth;
        Game.maxRadiation = 5f;
        Game.currRadiation = 0.1f;

        speed = 0.05f;

        maxX = 2.5f;
        maxY = 3f;
        minY = -4.5f;
        rb = GetComponent<Rigidbody2D>();

        PlayMode();

        // UI
        HealthBar.maxValue = maxHealth;
        HealthBar.value = currHealth;
        HealthBarLabel.text = currHealth.ToString();
        RadiationBar.maxValue = Game.maxRadiation;
        RadiationBar.value = Game.currRadiation;
        RadiationBarLabel.text = Game.currRadiation.ToString();
    }

    void Update()
    {
        if (!inPlay) return;

        // Update health
        HealthBar.value = currHealth;
        HealthBarLabel.text = currHealth.ToString("F2");
        // Update radiation
        RadiationBar.value = Game.currRadiation;
        RadiationBarLabel.text = Game.currRadiation.ToString("F3");

        if (Input.GetMouseButton(0))
        {
            Vector3 currPos = transform.position;
            transform.position = Move(currPos);
        }
    }

    public void Test() {
        print("testingg");
    }

    void PlayMode() {
        // MutationTree.SetActive(false);
        inPlay = true;
        cDecay = Decay();
        cShoot = ShootLaser();
        cTimer = Tick();
        StartCoroutine(cDecay);
        StartCoroutine(cShoot);
        StartCoroutine(cTimer);
    }

    void PauseMode() {
        MutationTree.SetActive(true);
        transform.position = Move(new Vector3(0, -4, 0));
        inPlay = false;
        Debug.Log("paused");
        StopCoroutine(cDecay);
        StopCoroutine(cShoot);
        StopCoroutine(cTimer);
    }

    IEnumerator Tick() {
        Timer.text = seconds.ToString() + "s";
        seconds += 1;
        yield return new WaitForSeconds(1f);
        cTimer = Tick();
        StartCoroutine(cTimer);
    }

    IEnumerator Decay() {
        Game.currRadiation *= Game.radiationConstant;
        if (Game.currRadiation > Game.maxRadiation) {
            Game.currRadiation = Game.maxRadiation;
        }
        yield return new WaitForSeconds(decayRate);
        cDecay = Decay();
        StartCoroutine(cDecay);
    }

    IEnumerator ShootLaser()
    {
        GameObject instance = Instantiate(PrefabLaser, transform.position, transform.rotation);
        // print("laser " + instance);
        yield return new WaitForSeconds(fireRate);
        cShoot = ShootLaser();
        StartCoroutine(cShoot);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy" || col.tag == "EBomb") TakeDamage(Game.currRadiation * 10f);
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Enemy" || col.tag == "EBomb") TakeDamage(Game.currRadiation * 0.5f);
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
