using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    #region public Objects
    public Canvas BeforeGameUICanvas = null;
    #endregion
    
    public void OnReloadMainMenu()
    {
        FlowManager.SetFlowState(GameState.MainMenu);
        //SceneManager.LoadScene(0);
    }

    public void OnReloadGame()
    {
        FlowManager.SetFlowState(GameState.InGame);
        // Show off game
        BeforeGameUICanvas.enabled = false;
        //SceneManager.LoadScene(1);
    }
}
