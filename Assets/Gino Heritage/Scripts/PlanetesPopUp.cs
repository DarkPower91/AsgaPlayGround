using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class PlanetesPopUp : MonoBehaviour
{
    #region Public fields
    [Readonly]
    public float neutrinoPercurredDistance = 0.0f;
    public ComputePercurredDistance playerDistanceComponent = null;
    public string extraTextBefore= "";
    public string extraTextAfter = "";
    #endregion

    #region Private fields
    private Text scoreText;
    private float mercuryDist = 0.3871f;
    private float venusDist = 0.723f;
    private float earthDist = 1.0f;
    private float marsDist = 1.52f;
    private float jupiterDist = 5.20f;
    private float saturnDist = 9.60f;
    private float uranusDist = 19.2f;
    #endregion

    void Start()
    {
        scoreText = GetComponent<Text>(); 
    }

    void Update()
    {
        if (playerDistanceComponent != null) 
        {
            if (FlowManager.GetGameState() == GameState.InGame) 
            {
                float distPerc = playerDistanceComponent.neutrinoPercurredDistance;

                if ( distPerc > mercuryDist && distPerc < venusDist ) 
                {
                    scoreText.text = extraTextBefore + " Mercury! " + extraTextAfter;
                }
                else if (distPerc > venusDist && distPerc < earthDist ) 
                {
                    scoreText.text = extraTextBefore + " Venus! " + extraTextAfter;
                }
                else if (distPerc > earthDist && distPerc < marsDist ) 
                {
                    scoreText.text = extraTextBefore + " Earth! Say hello to Gino!" + extraTextAfter;
                }
                else if (distPerc > marsDist && distPerc < jupiterDist )
                {
                    scoreText.text = extraTextBefore + " Mars! " + extraTextAfter;
                }
                else if (distPerc > jupiterDist && distPerc < saturnDist )
                {
                    scoreText.text = extraTextBefore + " Jupietr! " + extraTextAfter;
                }
                else if (distPerc > saturnDist && distPerc < uranusDist )
                {
                    scoreText.text = extraTextBefore + " Uranus! " + extraTextAfter;
                }
                else if (distPerc> uranusDist)
                {
                    scoreText.text = "You exit the solar system!";
                }
            }
        }
    }
}
