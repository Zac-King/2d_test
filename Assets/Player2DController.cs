using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(Player2D))]
public class Player2DController : MonoBehaviour
{
    private Player2D character;
    private bool jump;

    private void Awake()
    {
        character = GetComponent<Player2D>();
    }


    private void Update()
    {
        if (!jump)
        {
            // Read the jump input in Update so button presses aren't missed.
            jump = CrossPlatformInputManager.GetButtonDown("Jump");
        }
    }


    private void FixedUpdate()
    {
        // Read the inputs.
        bool crouch = Input.GetKey(KeyCode.LeftControl);
        float h = CrossPlatformInputManager.GetAxis("Horizontal");
        // Pass all parameters to the character control script.
        character.Move(h, crouch, jump);
        jump = false;
    }
}
