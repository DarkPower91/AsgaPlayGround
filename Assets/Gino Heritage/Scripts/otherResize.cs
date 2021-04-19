using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class otherResize : MonoBehaviour
{
    public float scalingMin = 4.5f;
    public float scalingMax = 7.5f;

    void Start()
    {
        float scalingOther = Random.Range(scalingMin, scalingMax);
        transform.localScale = new Vector3(scalingOther, scalingOther, 1.0f);
    }
}
