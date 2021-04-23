using UnityEngine;
using System;

public enum GameState //EDIT FLOW FOR LDJam48
{
    MainMenu,
    InCredits,
    InDex,
    InGame,
    InPause,
    GameOver
}

public class FlowManager : MonoBehaviour
{
    #region Private fields
    private static GameState m_CurrentState = GameState.MainMenu;
    #endregion

    public static Action<GameState> OnGameStateChanged = null;

    private void Start()
    {
        SetFlowState(GameState.MainMenu);
    }

    public static GameState GetGameState()
    {
        return m_CurrentState;
    }

    public static void SetFlowState(GameState state)
    {
        m_CurrentState = state;

        switch (m_CurrentState)
        {
            case GameState.InGame:
            case GameState.InCredits:
                {
                    Time.timeScale = 1;
                    break;
                }
            case GameState.MainMenu:
                {
                    Time.timeScale = 1;
                    SaveEvents.OnLoadInitiated();
                    break;
                }
            case GameState.GameOver:
                {
                    Time.timeScale = 1;
                    SaveEvents.OnSaveInitiated();
                    break;
                }
            case GameState.InPause:
                {
                    Time.timeScale = 0;
                    break;
                }

            case GameState.InDex:
            default:
                break;
        }
        OnGameStateChanged?.Invoke(m_CurrentState);
    }

#if UNITY_EDITOR
    void OnDestroy()
    {
        SaveLoad.ClearAllSaves();
    }
#endif

}
