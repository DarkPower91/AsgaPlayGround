using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    #region public objects
    public float health_bar = 100f;
    public float max_health = 200f;
    //public Transform explosionPrefab;
    #endregion

    #region private objects
    
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeHealth(float added_health=0f)
    {
        health_bar = Mathf.Clamp(health_bar + added_health, 0, max_health);
        GameplayEvents.OnHealthChange(health_bar);
        // If health too low, detrosy
        /* if (health_bar<=0f)
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, contact.normal);
            Vector3 position = contact.point;
            // What happens 
            Instantiate(explosionPrefab, position, rotation);
            gameObject.active = false;
            //Destroy(gameObject);
        } */
    }
    
}
