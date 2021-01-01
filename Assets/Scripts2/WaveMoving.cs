using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMoving : Wave
{

    private float waveTime = 10f;
    private Vector3 targetPosition;

    void Start()
    {
        targetPosition = new Vector3(0, -6, 0);
        StartCoroutine(MoveToPosition());

    }

    public IEnumerator MoveToPosition()
    {
        Vector3 currentPosition = transform.position;
        float t = 0f;
        while (t < 1)
        {
            t += Time.deltaTime / waveTime;
            transform.position = Vector3.Lerp(currentPosition, targetPosition, t);
            yield return null;
        }
    }
}
