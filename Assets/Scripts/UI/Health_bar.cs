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
    private Slider health_slider = null;
    private Health _player_health;
    #endregion
    
    private void Awake()
    {
        _mover = FindObjectOfType<CharacterMovements>();
        health_slider = GetComponent<Slider>();
        _player_health = FindObjectOfType<Health>();
        // Register events
        GameplayEvents.HealthChange.AddListener(ChangeSliderOnHealthChange);
        FlowManager.OnGameStateChanged += CheckHealthBarOnGameChange;
    }
    
    private void ChangeSliderOnHealthChange(float new_health) 
    {
        //Debug.Log("Changing health from " + _player_health.health_bar + " to " + new_health);
        // Change 
        health_slider.value = MathUtils.GetClampedPercentage(new_health, 0, _player_health.max_health);
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

    private void ChangeSliderVisibility(bool isVisible)
    {
        if (health_slider != null) 
        {
            health_slider.gameObject.SetActive(isVisible);
        }
    }

    private void CheckHealthBarOnGameChange(GameState new_gamestate)
    {
        //Debug.Log("New game state: " + new_gamestate);
        switch (new_gamestate)
        {
            case GameState.InGame:
                {
                    ChangeSliderVisibility(true);
                    break;
                }
            case GameState.MainMenu:
            case GameState.InCredits:
            case GameState.GameOver:
            case GameState.InPause:
            case GameState.InDex:
                {
                    ChangeSliderVisibility(false);
                    break;
                }
            default:
                break;
        }
    }
}
