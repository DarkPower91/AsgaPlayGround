using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float m_RotationSpeed = 0.0f;

    void Update()
    {
        transform.Rotate(Vector3.back, Time.deltaTime * m_RotationSpeed);    
    }
}
