using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HOW TO USE THIS SCRIPT IN YOUR OWN PROJECT
// - Create a capsule to use as a player.
// - Add a CharacterController Component to your player
// - Parent your camera to the player. 
// - Move the camera up, so it's where you want your player's eye level to be.
// - Attach this script to the camera.
// - That should be all you need! Tweak the settings here to your liking.
public class FirstPersonController : MonoBehaviour
{
    //Public Variables
    public float movementSpeed = 6.5f;
    public float strafeSpeed = 4f;
    public LayerMask groundMask;
    public float jumpForce = 10f;
    public float gravity = .98f;
    public float mouseSensitivityX = 2.2f;
    public float mouseSensitivityY = 2.2f;
    public Vector2 pitchBounds = new Vector2(-90, 35);

    //Local Variables
    Transform player;
    GameObject playerGO;
    CharacterController controller;
    float pitch = 0;
    float yaw = 0;

    float verticalVelocity = 0;
    bool grounded = true;
    void Start()
    {
        //Changes the lock state of our cursor to locked. 
        //This hides the cursor and keeps it locked to the center of the game view.
        //The CursorLockToggle method handles unlocking - to unlock or relock the cursor, press ESC.
        Cursor.lockState = CursorLockMode.Locked;

        //This code automatically grabs the references we need to components on the player object.
        player = transform.parent;
        playerGO = player.gameObject;
        controller = playerGO.GetComponent<CharacterController>();
    }


    void Update()
    {
        HandleRotation();

        HandleMovement();

        HandleVerticalMovement();

        CursorLockToggler();
    }

    void HandleVerticalMovement()
    {
        Vector3 vertVelocity = new Vector3(0, verticalVelocity + gravity, 0);

        grounded = checkGrounded();
        Debug.Log("Check grounded returned " + grounded);

        if (grounded) 
        {
            vertVelocity = new Vector3(0,gravity,0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded) 
        {
            vertVelocity += new Vector3(0, jumpForce, 0);
        }

        controller.Move(vertVelocity);

        verticalVelocity = vertVelocity.y;
    }

    bool checkGrounded() 
    {
        Vector3 origin = new Vector3(player.position.x, controller.bounds.min.y, player.position.z);

        Debug.DrawRay(origin, Vector3.down * controller.skinWidth);

        Ray ray = new Ray(origin, Vector3.down);

        if (Physics.Raycast(ray, controller.skinWidth * 1.01f, groundMask))
            return true;

        return false;
    }

    void HandleRotation() 
    {
        yaw += Input.GetAxis("Mouse X") * mouseSensitivityX;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivityY;

        //We clamp the pitch so that the player isn't able to rotate their head too far up or down.
        pitch = Mathf.Clamp(pitch, pitchBounds.x, pitchBounds.y);

        Vector3 targetPlayerRotation = new Vector3(0, yaw);
        player.eulerAngles = targetPlayerRotation;

        Vector3 targetHeadRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetHeadRotation;
    }

    void HandleMovement() 
    {
        Vector3 velocity = Vector3.zero;

        float forwardInput = Input.GetAxis("Vertical") * movementSpeed;
        float sideInput = Input.GetAxis("Horizontal") * strafeSpeed;

        velocity += (player.forward * forwardInput * Time.deltaTime) + (player.right * sideInput * Time.deltaTime);

        controller.Move(velocity);
    }

    void CursorLockToggler() 
    {
        //Using a ternary operator to handle switching back and forth between locked and unlocked cursor. When ESC is pressed.
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
