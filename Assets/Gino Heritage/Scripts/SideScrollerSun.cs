using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideScrollerSun : MonoBehaviour
{
    public float m_SunSpeed = 1.0f;
    public float m_SlideTime = 1.0f;

    public float m_Accumulator = 0.0f;

    void Update()
    {
        m_Accumulator += Time.deltaTime;
        if(m_Accumulator >= m_SlideTime)
        {
            Destroy(gameObject);
        }

        Vector3  newPos = new Vector3(transform.position.x - Time.deltaTime *m_SunSpeed, transform.position.y,transform.position.z);
        transform.position = newPos;
    }
}
