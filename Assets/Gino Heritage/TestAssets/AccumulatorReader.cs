using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  abstract class AccumulatorReader : MonoBehaviour
{
    protected static TestAccumulator accumulator = null;

    protected virtual void Start()
    {
        if(accumulator == null)
        {
            accumulator = GameObject.FindObjectOfType<TestAccumulator>();
        }
    }
}
