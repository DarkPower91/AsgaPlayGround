using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// Importante
using UnityEngine.UI;

public class Health_bar : MonoBehaviour
{  
    #region private objects
    private CharacterMovements _mover;
    private float dora_health = 100f;
    private Slider health_slider;
    private Health _player_health;
    #endregion
    
    private void Awake() {
        _mover = FindObjectOfType<CharacterMovements>();
        health_slider = GetComponent<Slider>();
        _player_health = FindObjectOfType<Health>();
        // Register events
        GameplayEvents.HealthChange.AddListener(ChangeSliderOnHealthChange);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        

       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ChangeSliderOnHealthChange(float new_health) 
    {
        //Debug.Log("Changing health from " + _player_health.health_bar + " to " + new_health);
        // Change 
        health_slider.value = Mathf.Clamp(
            new_health/_player_health.max_health,
            0,
            1
        );
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
