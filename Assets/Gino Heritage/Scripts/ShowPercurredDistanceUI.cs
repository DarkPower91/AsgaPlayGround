using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  // IMPORTANT!!!!!!!!

public class ShowPercurredDistanceUI : MonoBehaviour
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
    private float approxDist = 0.0f;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();         
    }

    // Update is called once per frame
    void Update()
    {       
        if (playerDistanceComponent != null) 
        {
            if (FlowManager.GetGameState() == GameState.InGame || FlowManager.GetGameState() == GameState.GameOver) 
            {
                approxDist = playerDistanceComponent.neutrinoPercurredDistance;
                string distToStiring = approxDist.ToString();

                if(distToStiring.Length>4)
                {
                    string exp = distToStiring.Substring(distToStiring.Length - 4);
                    string firstPart = distToStiring.Substring(0,4);
                    scoreText.text = LocalizationData.GetDescription(extraTextBefore) + " " + firstPart + exp + " " + LocalizationData.GetDescription(extraTextAfter);
                } 
                else 
                {
                    scoreText.text = LocalizationData.GetDescription(extraTextBefore) + " " + distToStiring + " " + LocalizationData.GetDescription(extraTextAfter);
                }
            }
        }
        
    }
}
