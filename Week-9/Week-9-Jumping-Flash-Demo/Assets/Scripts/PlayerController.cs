using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // This variable stores a "reference" to the CharacterController component
    // that is attached to the GameObject that this script is attached to
    // How do I know that? Because in the Start method, I assign it using GetComponent
    private CharacterController cc;
    [SerializeField] private float movementSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private float gravity;
    [SerializeField] private float jumpForce;
    private int jumpsLeft;
    private float verticalVelocity;
    
    // Camera Rotation
    private const float minRotation = 0;
    private const float maxRotation = 90;
    
    void Start()
    {
        // The GetComponent method returns a reference to the named component inside the <>
        cc = GetComponent<CharacterController>();
        jumpsLeft = 3;
    }

    // Update is called once per frame
    void Update()
    {
        // This line moves the player on the global z axis rather than the local z axis
        // Which works fine, until you turn/rotate, then not so much!
        //Vector3 move = new Vector3(0, 0, Input.GetAxis("Vertical"));

        // Only apply gravity if I am in the air (i.e. not on the ground)
        if (!cc.isGrounded)
        {
            // Gravity (acceleration) affects velocity
            verticalVelocity -= gravity;
        }
        else
        {
            jumpsLeft = 3;
        }

        // Jump 
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            if (jumpsLeft == 2)
            {
                // Start that rotation
                
            }
            jumpsLeft--;
            verticalVelocity = jumpForce;
        } 

        // So instead we use the local z-axis, denoted by transform.forward. Multiplying that
        // by the vertical axis gives either positive forward or negative forward (i.e. backward)
        
        // Velocity affects position
        Vector3 move = transform.forward * Input.GetAxis("Vertical") * movementSpeed +
                       new Vector3(0, verticalVelocity, 0);
        cc.Move(move * Time.deltaTime);
        
        // Rotation happens around an axis (in this case, up relative to the player) and by
        // a certain amount (for now, using the value of the Horizontal axis
        transform.Rotate(transform.up, Input.GetAxis("Horizontal") * rotationSpeed);
    }
}
