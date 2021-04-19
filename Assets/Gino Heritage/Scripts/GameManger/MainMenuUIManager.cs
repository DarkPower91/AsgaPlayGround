using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuUIManager : MonoBehaviour
{
    public GameObject MainCanvas = null;
    public GameObject DexCanvas = null;
    public GameObject CreditsCanvas = null;

    private GameObject ActiveCanvas = null;

    public void ActivateDex()
    {
        FlowManager.SetFlowState(GameState.InDex);
        ActiveCanvas.SetActive(false);
        DexCanvas.SetActive(true);
        ActiveCanvas = DexCanvas;
    }

    public void ActivateMainCanvas()
    {
        FlowManager.SetFlowState(GameState.MainMenu);
        ActiveCanvas.SetActive(false);
        MainCanvas.SetActive(true);
        ActiveCanvas = MainCanvas;
    }

    public void ActivateCreditsCanvas()
    {
        FlowManager.SetFlowState(GameState.InCredits);
        ActiveCanvas.SetActive(false);
        CreditsCanvas.SetActive(true);
        ActiveCanvas = CreditsCanvas;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    void Start()
    {
        ActiveCanvas = MainCanvas;
    }
}
