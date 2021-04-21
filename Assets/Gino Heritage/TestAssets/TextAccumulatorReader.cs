using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAccumulatorReader : AccumulatorReader
{
    private TMP_Text text = null;

    protected override void Start()
    {
        base.Start();
        text = GetComponent<TMP_Text>();
    }

    void Update()
    {
        text.text = accumulator.accumulator.ToString();
    }
}
