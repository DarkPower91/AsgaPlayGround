using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlanetsDB", menuName = "PlanetsDB", order = 1)]
public class PlanetDB : ScriptableObject
{
    public PlanetDefiner[] planets;
}

[System.Serializable]
public class PlanetDefiner 
{
    public string planetName;
    public float planetDistance;
    public GameObject planetGameObject;
}
