using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMoving : Wave
{
    private float speed;

    void Awake() {
        GameEvents.current.onGameOver += Dead;
    }

    void Start()
    { 
        speed = 1f;
        Initialize();
        StartCoroutine(SelfDestruct());
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -10, 0), speed * Time.deltaTime);
    }

    public override void Initialize()
    {
        base.Initialize();
    }

    void Dead() {
        print("self destruct");
        Destroy(gameObject);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(Game.waveTime * 3);
        Destroy(gameObject);
    }
}
