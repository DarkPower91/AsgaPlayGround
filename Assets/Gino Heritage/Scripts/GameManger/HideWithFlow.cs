using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideWithFlow : MonoBehaviour
{
    public GameState[] HiddenInFlowStates;

    void Start()
    {
        FlowManager.OnGameStateChanged += OnFlowStateChanged;
    }

    void OnDestroy()
    {
        FlowManager.OnGameStateChanged -= OnFlowStateChanged;
    }

    private void OnFlowStateChanged(GameState newState)
    {
        bool needToHide = false; 
        
        foreach(var state in HiddenInFlowStates)
        {
            needToHide |= newState == state;
        }

        this.gameObject.SetActive(!needToHide);
    }
}
