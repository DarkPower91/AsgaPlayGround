using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BoostListener : MonoBehaviour
{
    protected CharacterMovements _mover = null;

    private void Awake()
    {
        _mover = FindObjectOfType<CharacterMovements>();
        OnAwake();
    }

    private void Update()
    {
        if (_mover.IsBoostInRecharge())
        {
            DuringBoostRecharge();
        }
        else
        {
            DuringBoostAvailable();
        }
    }

    protected abstract void DuringBoostRecharge();
    protected abstract void DuringBoostAvailable();
    protected abstract void OnAwake();
}
