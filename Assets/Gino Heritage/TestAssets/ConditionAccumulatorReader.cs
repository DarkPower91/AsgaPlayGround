using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionAccumulatorReader : AccumulatorReader
{
    public float condition = 0.0f;
    public float m_ToColorSpeed = 1.0f;

    private bool active = false;
    private float shade = 1.0f;

    Material MaterialInstance = null;

    protected override void Start()
    {
        base.Start();
        
        Image image = GetComponent<Image>();
        MaterialInstance = Instantiate(image.material);
        image.material = MaterialInstance;
    }

    void Update()
    {
        if(accumulator.accumulator >= condition)
        {
            shade -= Mathf.Clamp01(Time.deltaTime * m_ToColorSpeed);
            MaterialInstance.SetFloat("_GrayscaleAmount", shade);
            if(shade<=0.0f)
            {
                enabled = false;
            }
        }
    }
}
