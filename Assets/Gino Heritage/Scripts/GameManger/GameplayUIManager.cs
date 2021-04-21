using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayUIManager : MonoBehaviour
{
    public GameObject m_GameOverCanvas = null;
    public GameObject m_DexCanvas = null;

    private GameObject m_ActiveCanvas = null;

    public void ActivateDex()
    {
        m_ActiveCanvas.SetActive(false);
        m_DexCanvas.SetActive(true);
        m_ActiveCanvas = m_DexCanvas;
    }

    public void ActivateGameOver()
    {
        m_ActiveCanvas.SetActive(false);
        m_GameOverCanvas.SetActive(true);
        m_ActiveCanvas = m_GameOverCanvas;
    }

    void Start()
    {
        m_ActiveCanvas = m_GameOverCanvas;
    }
}