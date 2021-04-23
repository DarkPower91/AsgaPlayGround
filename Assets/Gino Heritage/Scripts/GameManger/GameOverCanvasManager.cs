using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvasManager : MonoBehaviour
{
    public List<GameObject> m_GameOverCanvas = null;

    private void Start()
    {
        foreach (GameObject go in m_GameOverCanvas)
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
        if (newState == GameState.GameOver)
        {
            foreach (GameObject go in m_GameOverCanvas)
            {
                go.SetActive(true);
            }
        }
    }

    void UpdateFtue()
    {
        GinoSaveData.ftue = false;
    }
}
