using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class BoostColorChange : BoostListener
{
    public Color AvailableColor;
    public Color RechargeColor;

    private SpriteRenderer _renderer = null;

    protected override void OnAwake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    protected override void DuringBoostAvailable()
    {
        if (_renderer != null)
        {
            _renderer.material.color = AvailableColor;
        }
    }

    protected override void DuringBoostRecharge()
    {
        if (_renderer != null)
        {
            _renderer.material.color = RechargeColor;
        }
    }
}
