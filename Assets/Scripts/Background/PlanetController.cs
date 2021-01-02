using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] Planets;
    Queue<GameObject> availablePlanets = new Queue<GameObject>();

    void Start()
    {
        availablePlanets.Enqueue(Planets[0]);
        availablePlanets.Enqueue(Planets[1]);
        availablePlanets.Enqueue(Planets[2]);

        InvokeRepeating("MovePlanetDown", 0, 20f);
    }

    void Update()
    {

    }

    void MovePlanetDown()
    {
        EnqueuePlanets();

        if (availablePlanets.Count == 0) return;

        GameObject planet = availablePlanets.Dequeue();

        planet.GetComponent<Planet>().isMoving = true;
    }

    void EnqueuePlanets()
    {
        foreach (GameObject planet in Planets)
        {
            if ((planet.transform.position.y < 0) && (!planet.GetComponent<Planet>().isMoving))
            {
                planet.GetComponent<Planet>().ResetPosition();

                availablePlanets.Enqueue(planet);
            }
        }
    }
}
