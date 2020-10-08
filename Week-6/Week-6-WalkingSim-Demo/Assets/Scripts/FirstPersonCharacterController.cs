using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*Implimentation Steps
 - Create a capsule to be your player object.
 - Add a CharacterController component to your player.
 - Parent the camera to the player, and position it in their head.
 - Add this script to that camera.
 - Adjust settings according to your needs.
*/

public class FirstPersonCharacterController : MonoBehaviour
{
    #region Serialized Settings
    [Header("Speed Settings")]
    [SerializeField]
    float movementSpeed = 6.5f;
    [SerializeField]
    float strafeSpeed = 4f;
    [SerializeField]
    float sprintSpeedMod = 2;
    [SerializeField]
    float crouchSpeedMod = .5f;
    
    [Space]
    [Header("Crouch Settings")]
    [SerializeField, Range(.01f, 1)]
    float crouchHeight = .6f;
    [SerializeField, Range(.01f, 1)]
    float moveToCrouchSpeed = .1f;
    [SerializeField, Range(.01f, 1)]
    float moveFromCrouchSpeed = .2f;
    
    [Space]
    [Header("Jump Settings")]
    [SerializeField]
    float gravity = .98f;
    [SerializeField]
    float jumpForce = 14;
    [SerializeField]
    int airJumps = 0;

    [Space]
    [Header("View Settings")]
    [SerializeField]
    float mouseSensitivityX = 2.2f;
    [SerializeField]
    float mouseSensitivityY = 2.2f;
    [SerializeField]
    Vector2 yawBounds = new Vector2(-90, 35);
    #endregion

    #region Local Variables
    Transform player;
    GameObject playerGO;
    CharacterController controller;
    CollisionFlags collisions;

    float pitch = 0;
    float yaw = 0;

    float airJumpCounter = 0;
    
    float crouchT = 0;
    bool crouched = false;

    Vector3 velocity;
    #endregion

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        player = transform.parent;
        playerGO = player.gameObject;
        controller = playerGO.GetComponent<CharacterController>();
    }

    void Update()
    {
        #region Rotations
        pitch += Input.GetAxis("Mouse X") * mouseSensitivityX;
        yaw -= Input.GetAxis("Mouse Y") * mouseSensitivityY;

        yaw = Mathf.Clamp(yaw, yawBounds.x, yawBounds.y);

        Vector3 targetPlayerRotation = new Vector3(0, pitch);
        player.eulerAngles = targetPlayerRotation;

        Vector3 targetHeadRotation = new Vector3(yaw, pitch);
        transform.eulerAngles = targetHeadRotation;
        #endregion

        #region Movement
        Vector3 pVelocity = velocity;
        velocity = new Vector3(0, velocity.y, 0);

        float forwardInput = Input.GetAxis("Vertical") * movementSpeed;
        float sideInput = Input.GetAxis("Horizontal") * strafeSpeed;

        //Handle Sprinting & Crouching
        if (Input.GetKey(KeyCode.LeftShift) && (pVelocity.x > 0 || pVelocity.z > 0)) 
        {
            forwardInput *= sprintSpeedMod;
        } else if (Input.GetKey(KeyCode.LeftControl) && controller.isGrounded) 
        {
            forwardInput *= crouchSpeedMod;
            sideInput *= crouchSpeedMod;
        }
        //If we're holding crouch, crouch, if we're not holding crouch, uncrouch
        //If we're standing, simply return.
        handleCrouch();

        //Handle Jumping
        if (controller.isGrounded)
        {
            velocity.y = 0;
            airJumpCounter = 0;
            if(Input.GetKeyDown(KeyCode.Space) && !crouched)
                velocity.y = jumpForce * Time.deltaTime;
        } else if (Input.GetKeyDown(KeyCode.Space) && airJumpCounter < airJumps) 
        {
            velocity.y = jumpForce * Time.deltaTime;
            airJumpCounter++;
        }

        velocity += (player.forward * forwardInput * Time.deltaTime) + (player.right * sideInput * Time.deltaTime) + (Vector3.down * gravity * Time.deltaTime);


        collisions = controller.Move(velocity);

        if ((controller.collisionFlags & CollisionFlags.Above) != 0) 
        {
            velocity.y = 0;
        }
        #endregion

        //Shortcut for locking & unlocking the cursor
        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = (Cursor.lockState == CursorLockMode.Locked) ? CursorLockMode.None : CursorLockMode.Locked;
    }

    void handleCrouch() 
    {
        if (Input.GetKey(KeyCode.LeftControl) && !Input.GetKey(KeyCode.LeftShift) && controller.isGrounded) 
        {
            crouched = true;
           crouchT += moveToCrouchSpeed;
        } else if(player.localScale.y < 1) 
        {
            Ray headRay = new Ray(new Vector3(player.transform.position.x, controller.bounds.max.y, player.transform.position.z), Vector3.up * .1f);
            
            if(!Physics.Raycast(headRay))
            crouchT -= moveFromCrouchSpeed;
        } else 
        {
            crouched = false;
            return;
        }

        crouchT = Mathf.Clamp(crouchT, 0, 1);

        float y = Mathf.Lerp(1, crouchHeight, crouchT);
        player.localScale = new Vector3(player.localScale.x, y, player.localScale.z);

        if(controller.isGrounded)
            controller.Move(Vector3.down);
    }
}
