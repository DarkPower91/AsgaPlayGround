using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void OnReloadMainMenu()
    {
        FlowManager.SetFlowState(GameState.MainMenu);
        SceneManager.LoadScene(0);
    }

    public void OnReloadGame()
    {
        FlowManager.SetFlowState(GameState.InGame);
        SceneManager.LoadScene(1);
    }
}
