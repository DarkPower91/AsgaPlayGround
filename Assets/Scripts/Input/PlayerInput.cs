using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DefaultExecutionOrder(-100)]
public class PlayerInput : MonoBehaviour
{
    public Joystick joystick = null;
    private bool isUsingTouch = false;

    [HideInInspector] public float horizontal;
    [HideInInspector] public float vertical;
    [HideInInspector] public bool jumpPressed;
    [HideInInspector] public bool jumpHeld;
    [HideInInspector] public bool fire1Pressed;
    [HideInInspector] public bool fire1Held;
    [HideInInspector] public bool fire2Pressed;
    [HideInInspector] public bool fire2Held;

    private bool readyToClear;

    private void Update()
    {
        ClearInput();

        //FLOW MANAGER CHECK IF GAME OVER
        //RETURN;

        ProcessInputs();

        horizontal = Mathf.Clamp(horizontal, -1.0f, 1.0f);
        vertical = Mathf.Clamp(vertical, -1.0f, 1.0f);
    }

    private void FixedUpdate()
    {
        readyToClear = true;
    }

    private void ClearInput()
    {
        if (!readyToClear)
        {
            return;
        }

        horizontal = 0;
        vertical = 0;
        jumpPressed = false;
        jumpHeld = false;
        fire1Pressed = false;
        fire1Held = false;
        fire2Pressed = false;
        fire2Held = false;
    }

    private void ProcessInputs()
    {
        //Axis
        horizontal   += isUsingTouch && joystick != null ? joystick.Horizontal : Input.GetAxisRaw("Horizontal");
        vertical     += isUsingTouch && joystick != null ? joystick.Vertical : Input.GetAxisRaw("Vertical");

        //Jump
        jumpPressed  |= Input.GetButtonDown("Jump");
        jumpHeld     |= Input.GetButton("Jump");

        //Fire1
        fire1Pressed |= Input.GetButtonDown("Fire1");
        fire1Held    |= Input.GetButton("Fire1");

        //Fire2
        fire2Pressed |= Input.GetButtonDown("Fire2");
        fire2Held    |= Input.GetButton("Fire2");
    }
}
