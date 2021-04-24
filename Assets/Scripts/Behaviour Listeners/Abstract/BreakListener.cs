using UnityEngine;

public abstract class BreakListener : MonoBehaviour
{
    protected CharacterMovements _mover = null;

    private void Awake()
    {
        _mover = FindObjectOfType<CharacterMovements>();
        OnAwake();
    }

    protected void Update()
    {
        if(_mover.IsBreakInRecharge())
        {
            DuringBreakRecharge();
        }
        else
        {
            DuringBreakAvailable();
        }
    }

    protected abstract void DuringBreakRecharge();
    protected abstract void DuringBreakAvailable();
    protected abstract void OnAwake();
}
