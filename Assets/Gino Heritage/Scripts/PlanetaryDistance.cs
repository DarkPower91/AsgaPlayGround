using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class PlanetaryDistance : MonoBehaviour
{
    #region Public fields
    [Readonly]
    public float neutrinoPercurredDistance = 0.0f;
    public ComputePercurredDistance playerDistanceComponent = null;
    public string extraTextBefore = "";
    public string extraTextAfter = "";
    public float timeExposedString = 3.0f;
    public PlanetDB planets;
    #endregion 

    private Text scoreText;
    private bool[] isReachedArray;
    private int idx = 0;

    void Start()
    {
        scoreText = GetComponent<Text>(); 
        isReachedArray = new bool[planets.planets.Length];
    }

    void Update()
    {
        if (playerDistanceComponent != null) 
        {
            if (FlowManager.GetGameState() == GameState.InGame) 
            {
                foreach(PlanetDefiner planet in planets.planets)
                {
                    if (!isReachedArray[idx])
                    {
                        if (playerDistanceComponent.neutrinoPercurredDistance >= planet.planetDistance)
                        {

                            scoreText.text = LocalizationData.GetDescription(extraTextBefore)
                                             + " " 
                                             + LocalizationData.GetDescription(planet.planetName)
                                             + LocalizationData.GetDescription(extraTextAfter);

                            isReachedArray[idx] = true;
                            StartCoroutine(AwaitFunc());
                        }
                    }
                    idx++;
                }
                idx=0; 
            }
        }
    }

    IEnumerator AwaitFunc() 
    {
        yield return new WaitForSeconds(timeExposedString);

        scoreText.text = "";
    }
}
