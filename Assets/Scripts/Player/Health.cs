using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region public objects
    public float health_bar = 100f;
    
    //public Transform explosionPrefab;
    #endregion

    #region private objects
    
    #endregion

    #region private Serialize Field objects
    [SerializeField]
    private float _max_health = 200f;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
       // Set the initial Health
       ChangeHealth(0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(float added_health=0f)
    {
        
        health_bar = Mathf.Clamp(health_bar + added_health, 0, _max_health);
        //Debug.Log("Invoking health change event with new health " + health_bar);
        GameplayEvents.OnHealthChange(health_bar);
    }

    public float max_health 
    {
        get
        {
            return _max_health;
        }
    }
    
}
