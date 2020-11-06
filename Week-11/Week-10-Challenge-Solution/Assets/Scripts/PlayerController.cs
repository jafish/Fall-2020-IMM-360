using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
    public GameObject fpsCamera;
    private int rotationState; // 1 = Normal, 2 = Normal->Jumping, 3 = Jumping, 4 = Jumping->Normal 
    private const float minRotation = 0;
    private const float maxRotation = 90;

    private float currentRotation = minRotation;
    
    // Projectiles
    public GameObject shot;
    
    void Start()
    {
        // The GetComponent method returns a reference to the named component inside the <>
        cc = GetComponent<CharacterController>();
        jumpsLeft = 3;
        rotationState = 1;
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
            if (rotationState == 3)
            {
                currentRotation -= rotationSpeed;
                if (currentRotation < 0)
                {
                    currentRotation = 0;
                    rotationState = 0;
                }
                fpsCamera.transform.Rotate(Vector3.right, -rotationSpeed);
            }
        }

        // Jump 
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpsLeft > 0)
        {
            if (jumpsLeft == 2)
            {
                // Start that rotation
                rotationState = 2;
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

        if (rotationState == 2)
        {
            // Rotate the camera
            currentRotation += rotationSpeed;

            // Check if I'm done with rotating
            if (currentRotation > maxRotation)
            {
                currentRotation = maxRotation;
                rotationState = 3;
            }
            fpsCamera.transform.Rotate(Vector3.right, rotationSpeed);
        }
        
        // Shoot
        if (Input.GetMouseButtonDown(0))
        {
            GameObject p1 = Instantiate(shot);
            p1.transform.position = transform.position + transform.right;
            GameObject p2 = Instantiate(shot);
            p2.transform.position = transform.position - transform.right;
            p1.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
            p2.GetComponent<Rigidbody>().AddForce(transform.forward * 20, ForceMode.Impulse);
        }
    }
}
