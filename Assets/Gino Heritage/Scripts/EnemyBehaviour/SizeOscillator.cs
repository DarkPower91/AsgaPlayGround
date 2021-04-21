using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeOscillator : MonoBehaviour
{
    public float m_ChangeDuration = 3.0f;
    public float m_MultiplicativeFactor = 1.3f;
    public float checcaFactor = (4.0f/3.0f);

    private CircleCollider2D m_Collider = null;
    private float m_BaseRadius = 1.0f;
    private float m_StartTime = 0.0f;
    private float m_ExpectedMaxRadius = 0.0f;
    private float m_ExpectedMinRadius = 0.5f;
    private float m_ScalingFactor_x = 1.0f;
    private float m_ScalingFactor_y = 1.0f;
    
    void Start()
    {
        m_Collider = GetComponent<CircleCollider2D>();

        m_BaseRadius = m_Collider.radius;
        m_StartTime = Time.time;

        m_ExpectedMaxRadius = m_MultiplicativeFactor*m_BaseRadius*checcaFactor;
        m_ExpectedMinRadius = m_BaseRadius/m_MultiplicativeFactor;
        
        m_ScalingFactor_x = transform.localScale.x/m_BaseRadius;
        m_ScalingFactor_y = transform.localScale.y/m_BaseRadius;
    }

    void Update()
    {
        float stepSize = (Time.time - m_StartTime) / m_ChangeDuration;
        var newRadius = m_Collider.radius;
        
        newRadius = Mathf.SmoothStep(m_ExpectedMinRadius, m_ExpectedMaxRadius, stepSize);

        m_Collider.radius = newRadius;

        transform.localScale = new Vector3 (m_ScalingFactor_x * newRadius, m_ScalingFactor_y * newRadius, transform.localScale.z);

        if(stepSize >= 1.0)
        {
            float swapTemp = m_BaseRadius;

            m_BaseRadius = m_ExpectedMaxRadius;
            m_ExpectedMaxRadius = swapTemp;

            m_StartTime = Time.time;
        }
    }
}
