using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsSpawner : MonoBehaviour
{
    public ComputePercurredDistance playerPercurredDistance;
    public PlanetDB planets;
    public float beforeDistance = 0.2f;
    public float speed=4;
    private bool[] isAppearedYet;
    private int idx = 0;

    void Start()
    {
        isAppearedYet = new bool[planets.planets.Length];
    }

    void Update()
    {
        if (playerPercurredDistance != null) 
        {
            float distancePercurred = playerPercurredDistance.getPercurredDistance();

            if (FlowManager.GetGameState() == GameState.InGame) 
            {
                foreach(PlanetDefiner planet in planets.planets)
                {
                    if (!isAppearedYet[idx])
                    {
                        // The planets spawns "beforeDistance" UA before reaching it
                        if (distancePercurred >= planet.planetDistance - beforeDistance)
                        {
                            spawnPlanet(idx);
                            isAppearedYet[idx] = true;                          
                        }
                    }
                    idx++;
                }
                idx=0; 
            }
        }
    }

    void spawnPlanet(int idx) 
    {
        if (idx < planets.planets.Length && idx >= 0) 
        {
            GameObject planet = Instantiate(planets.planets[idx].planetGameObject) as GameObject;

            Vector2 screenBounds = ScreenBounds.GetScreenBounds();
            float xPosition = screenBounds.x * 1.2f;
            float yPosition = 0;
            float zPosition = 9;

            planet.transform.position = new Vector3(xPosition, yPosition, zPosition);
            planet.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);

        }
    } 

    void removePlanet(int idx) 
    {

    }


}
