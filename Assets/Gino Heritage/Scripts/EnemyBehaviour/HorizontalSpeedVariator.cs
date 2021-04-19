using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpeedVariator : MonoBehaviour
{
    public float m_ChangeTime = 1.0f;
    public float m_MaxTopSpeed = 5.0f;

    private Rigidbody2D m_rigidbody = null;
    private Vector2 m_BaseVelocity;

    private Vector2 m_NextSpeed;
    private bool oscillator = false;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_BaseVelocity = m_rigidbody.velocity;
        m_NextSpeed = m_BaseVelocity;
        StartCoroutine(Variate());
    }

    IEnumerator Variate()
    {
        while(true)
        {
            m_rigidbody.velocity = m_NextSpeed;
            float nextTopSpeed = oscillator? Mathf.Clamp(2 * m_BaseVelocity.x, 0, m_MaxTopSpeed) : m_BaseVelocity.x;
            m_NextSpeed = new Vector2(nextTopSpeed, m_BaseVelocity.y);
            oscillator = !oscillator;
            yield return new WaitForSeconds(oscillator? m_ChangeTime : m_ChangeTime*2);
        }
    }
}
