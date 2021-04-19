using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class VerticalOscillator : MonoBehaviour
{
    public float m_MinChangeRate = 0.1f;
    public float m_MaxChangeRate =  0.6f;
    public float m_VerticalVelocity = 2.0f;

    private Rigidbody2D m_rigidbody = null;
    private float  m_NextVeloxity = 0.0f;
    private float m_ChangeTime = 0.0f;

    void Start()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
        m_NextVeloxity = m_VerticalVelocity;
        m_ChangeTime = Random.Range(m_MinChangeRate, m_MaxChangeRate);
        StartCoroutine(Oscillate());
    }

    IEnumerator Oscillate()
    {
        while(true)
        {
            Vector2 currentVelocity = m_rigidbody.velocity;
            Vector2 newVelocity = new Vector2(currentVelocity.x, m_NextVeloxity);
            m_rigidbody.velocity = newVelocity;
            m_NextVeloxity *= -1;
            yield return new WaitForSeconds(m_ChangeTime);
        }
    }
}
