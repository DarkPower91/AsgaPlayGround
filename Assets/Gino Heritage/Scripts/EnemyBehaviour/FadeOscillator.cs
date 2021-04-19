using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOscillator : MonoBehaviour
{
    public float m_ChangeDuration = 3.0f;
    public float m_MinAlpha = 0.3f;

    private SpriteRenderer m_Renderer = null;
    private float m_BaseAlpha = 1.0f;
    private float m_ExpectedMinAlpha = 0.0f;
    private float m_StartTime = 0.0f;

    void Start()
    {
        m_Renderer = GetComponent<SpriteRenderer>();
        m_BaseAlpha = m_Renderer.material.color.a;
        m_ExpectedMinAlpha = m_MinAlpha;
        m_StartTime = Time.time;
    }

    private void Update() 
    {
        float stepSize = (Time.time - m_StartTime) / m_ChangeDuration;
        var newColor = m_Renderer.material.color;
        newColor.a = Mathf.SmoothStep(m_BaseAlpha, m_ExpectedMinAlpha, stepSize);

        m_Renderer.material.color = newColor;

        if(stepSize >= 1.0)
        {
            float swapTemp = m_BaseAlpha;
            m_BaseAlpha = m_ExpectedMinAlpha;
            m_ExpectedMinAlpha = swapTemp;
            m_StartTime = Time.time;
        }
    }
}
