using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class BreakColorChange : BreakListener
{
    public Color AvailableColor;
    public Color RechargeColor;

    private Renderer _renderer = null;

    protected override void OnAwake()
    {
        _renderer = GetComponent<Renderer>();
    }

    protected override void DuringBreakAvailable()
    {
        if(_renderer != null)
        {
            _renderer.material.color = AvailableColor;
        }
    }

    protected override void DuringBreakRecharge()
    {
        if (_renderer != null)
        {
            _renderer.material.color = RechargeColor;
        }
    }
}
