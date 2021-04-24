using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
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
    #endregion

    #region Private objects
    private Vector2 direction_versor = new Vector2(1.0f, 0.0f);
    private Vector2 applied_integrated_force = new Vector2(1.0f, 0.0f);
    private Vector2 axis_position;
    private bool isUsingTouch = false;
    private Rigidbody2D bolla_component;
    #endregion
    
    // Start is called before the first frame update
    void Start()
    {
        bolla_component = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() 
    {
        // ///////////////////////
        // Normal movement with arrows
        // The physics is 
        // F = m*\vec{a} - k v^2 \vers{x},  
        // Friction setted by linear drag in RigidBody
        axis_position = transform.position; 
        
        direction_versor[0] = isUsingTouch && joystick != null ? joystick.Horizontal :  Input.GetAxisRaw("Horizontal");
        direction_versor[1] = isUsingTouch && joystick != null ? joystick.Vertical :  Input.GetAxisRaw("Vertical");
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
            
        } else
        {
            // Here instead players applies force
            if (direction_versor.magnitude > 0) 
            {
                bolla_component?.AddForce(standard_thrust*direction_versor);
            }
            
            //bolla_component?.AddForce(standard_thrust*direction_versor, ForceMode2D.Impulse);
        }
        
 
        // ///////////////////////
        // Boost
        if (Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1")) 
        {
            // Forza impulsiva
            bolla_component?.AddForce(strenght_jump * direction_versor, ForceMode2D.Impulse);
        } else if (Input.GetButtonDown("Fire2"))
        {
            // Frenamento impulsiva
            bolla_component?.AddForce( - strenght_break * direction_versor, ForceMode2D.Impulse);
        }


    }
}
