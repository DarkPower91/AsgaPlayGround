using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputePercurredDistance : MonoBehaviour
{
    #region Public fields
    public float neutrinoPercurredDistance = 0.0f;
    public float JamModifier = 3.0f;
    #endregion

    #region Private fields
    private float currentTime = 0.0f;
    private float startTime = 0.0f;
    private float powerUpExtra = 0.0f;
    #endregion

    private void Awake() {
        currentTime = 0.0f;
        startTime = 0.0f;
        neutrinoPercurredDistance = 0.0f;

    }

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (FlowManager.GetGameState() == GameState.InGame) 
        {
            currentTime =  Time.time - startTime;      
            /*
                Il neutrino va circa alla velocità della luce; 
                dunque, in anni luce, percorre 
                currentTime (yrs)
                Fine. 
                Dunque, succome CurrentTime è in secondi, basta convertirlo in anni.
                1 sec = 1/60/60/24/365 yrs
                per cui
                1 yrs  = 1 * 60*60*24*365 sec
                In unità astronomiche invece
                1 light-yrss = 63 241.08 AU
                In chilometri invece

            */
            neutrinoPercurredDistance = powerUpExtra + JamModifier * (63241.08f)*(0.995f)*currentTime/(60*60*24*365.25f); 
        }
        
    }

    public void addAmount(float amount) 
    {
        powerUpExtra += amount;
    }

    public float getPercurredDistance() 
    {
        return neutrinoPercurredDistance;
    }
}
