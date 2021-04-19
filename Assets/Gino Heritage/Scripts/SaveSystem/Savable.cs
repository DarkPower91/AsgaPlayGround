using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Savable : MonoBehaviour
{
    private void Start()
    {
        SaveEvents.SaveInitiated += OnSave;
        SaveEvents.LoadInitiated += OnLoad;
    }

    private void OnDestroy() 
    {
        SaveEvents.SaveInitiated -= OnSave;
        SaveEvents.LoadInitiated -= OnLoad;   
    }

    protected abstract void OnSave();
    protected abstract void OnLoad();
}
