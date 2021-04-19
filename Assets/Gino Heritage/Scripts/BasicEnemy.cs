using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BasicEnemy : MonoBehaviour
{
    #region private Fields
    private float m_Speed = 0;
    private Rigidbody2D m_Rigidbody;
    private Vector2 m_ScreenBounds;
    #endregion

    void Start()
    {
        m_Rigidbody = this.GetComponent<Rigidbody2D>();
        m_Rigidbody.velocity = new Vector2(-m_Speed, m_Rigidbody.velocity.y);
        m_ScreenBounds = ScreenBounds.GetScreenBounds();
    }

    void Update()
    {
        if(transform.position.x < -m_ScreenBounds.x * 1.5f)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetSpeed(float speed)
    {
        m_Speed = speed;
    }

}
