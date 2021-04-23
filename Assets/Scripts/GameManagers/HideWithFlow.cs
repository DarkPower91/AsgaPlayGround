using UnityEngine;

public class HideWithFlow : MonoBehaviour
{
    public GameState[] HiddenInFlowStates;

    private void Start()
    {
        FlowManager.OnGameStateChanged += OnFlowStateChanged;
    }

    private void OnDestroy()
    {
        FlowManager.OnGameStateChanged -= OnFlowStateChanged;
    }

    private void OnFlowStateChanged(GameState newState)
    {
        bool needToHide = false;

        foreach (GameState state in HiddenInFlowStates)
        {
            needToHide |= newState == state;
        }

        gameObject.SetActive(!needToHide);
    }
}
