using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMoving : Wave
{
    private float speed;
    void Start()
    {
        speed = 1f;
        StartCoroutine(SelfDestruct());
    }

    void Update()
    {
        // foreach (Transform child in transform)
        // {
        //     GameObject enemy = child.gameObject;
        //     enemy.GetComponent<Rigidbody2D>().velocity = transform.up * -speed;
        // }
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, -6, 0), speed * Time.deltaTime);
    }

    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(Game.waveTime * 2);
        Destroy(gameObject);
    }
}
