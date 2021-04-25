using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerInput))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterMovements : MonoBehaviour
{
    #region Public objects
    public Vector3 startingPosition;
    public float velocity_module = 2.0f;
    public float standard_thrust = 0.9f;
    public float strenght_jump = 1.2f;
    public float strenght_break = 0.8f;
    public Joystick joystick = null;
    public bool isForceMode = true;
    public float duration_break = 5f;
    public float duration_jump = 5f;
    #endregion

    #region Private objects
    private Vector2 direction_versor = new Vector2(1.0f, 0.0f);
    private Vector2 applied_integrated_force = new Vector2(1.0f, 0.0f);
    private Vector2 axis_position;
    private bool isUsingTouch = false;
    private Rigidbody2D bolla_component;
    private Timer _Timer_jump = new Timer();
    private Timer _Timer_break = new Timer();
    private PlayerInput _input = null;
    #endregion

    private void Start()
    {
        // Initialize component
        bolla_component = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();

        // Initialize timers
        _Timer_break.Start();
        _Timer_jump.Start();
        
    }

    private void FixedUpdate() 
    {
        // ///////////////////////
        // Normal movement with arrows
        // The physics is 
        // F = m*\vec{a} - k v^2 \vers{x},  
        // Friction setted by linear drag in RigidBody
        axis_position = transform.position;

        direction_versor[0] = _input.horizontal;
        direction_versor[1] = _input.vertical;
        direction_versor.Normalize();

        // Constant Acceleration case
        if (!isForceMode) 
        {
            // Change velocity only if player did stuff
            if (direction_versor.magnitude > 0) 
            {
                applied_integrated_force = velocity_module*direction_versor;
                // Since acceleration is constant we use setVelocity
                bolla_component.velocity = applied_integrated_force;
            }
            
        } else // We mainly use this
        {
            // Here instead players applies force
            if (direction_versor.magnitude > 0) 
            {
                bolla_component?.AddForce(standard_thrust*direction_versor);
            }
            // Other version - commented out
            //bolla_component?.AddForce(standard_thrust*direction_versor, ForceMode2D.Impulse);
        }
        
 
        // ///////////////////////
        // Boost
        // it is triggere every tot seconds
        // Case 1: Jump
        if ( _Timer_jump.IsStartedYet() &&  _Timer_jump.IsElapsed()) 
        {
            if ( _input.jumpPressed || _input.fire1Pressed)
            {
                // Forza impulsiva
                bolla_component?.AddForce(strenght_jump * direction_versor, ForceMode2D.Impulse);

                // Reset timer
                _Timer_jump.Start(duration_break);
            } 
        }
        // Case 2: Break
        if ( _Timer_break.IsStartedYet() &&  _Timer_break.IsElapsed()) 
        {
            if ( _input.fire2Pressed)
            {
                if (direction_versor.magnitude > 0) 
                {
                    // Frenamento impulsiva
                    bolla_component?.AddForce( - strenght_break * direction_versor, ForceMode2D.Impulse);

                    // reset timer
                    _Timer_break.Start(duration_break);
                }
                
            }
        }
    }

    public bool IsBoostInRecharge()
    {
        return !_Timer_jump.IsElapsed();
    }

    public bool IsBreakInRecharge()
    {
        return !_Timer_break.IsElapsed();
    }
}
