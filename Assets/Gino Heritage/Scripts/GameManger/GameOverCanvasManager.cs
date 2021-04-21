using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvasManager : MonoBehaviour
{
    public List<GameObject> m_GameOverCanvas = null;
    void Start()
    {
        foreach(var go in m_GameOverCanvas)
        {
            go.SetActive(false);
        }
        FlowManager.OnGameStateChanged += OnGameStateChanged;
        SaveEvents.DataUpdateNeeded += UpdateFtue;

    }

    private void OnDestroy() 
    {
        FlowManager.OnGameStateChanged -= OnGameStateChanged;   
        SaveEvents.DataUpdateNeeded -= UpdateFtue;
    }

    private void OnGameStateChanged(GameState newState)
    {
        if(newState == GameState.GameOver)
        {
            foreach(var go in m_GameOverCanvas)
            {
                go.SetActive(true);
            }
        }
    }

    void UpdateFtue()
    {
        SaveData.ftue = false; 
    }
}
