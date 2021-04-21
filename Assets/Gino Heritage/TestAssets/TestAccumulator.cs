using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestAccumulator : MonoBehaviour
{
    private float _accumulator = 0.0f;
    public float accumulator {get {return _accumulator;}}

    void Update()
    {
        _accumulator += Time.deltaTime;
    }
}
