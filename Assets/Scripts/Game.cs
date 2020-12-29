using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    float mapX = 5f;
    float mapY = 3f;

    private float minX;
    private float maxX;
    private float minY;
    private float maxY;

    void Start()
    {
        var vertExtent = Camera.main.GetComponent<Camera>().orthographicSize;
        var horzExtent = vertExtent * Screen.width / Screen.height;

        // Calculations assume map is position at the origin
        minX = horzExtent - mapX / 2.0f;
        maxX = mapX / 2.0f - horzExtent;
        minY = vertExtent - mapY / 2.0f;
        maxY = mapY / 2.0f - vertExtent;

        Debug.LogFormat("Boundaries: {0} {0} {0} {0}", minX, minY, maxX, maxY);
    }

    void Update()
    {

    }
}
