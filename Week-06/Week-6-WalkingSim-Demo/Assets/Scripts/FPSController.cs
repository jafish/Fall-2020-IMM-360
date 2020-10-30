using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    // 1. Move in local space directions with arrow keys
    // 2. Camera follows mouse
    public Transform playerTransform;
    public CharacterController playerCharacterController;
    public float sensitivity;
    public float speed;
    float pitch = 0;
    float yaw = 0;

    // Update is called once per frame
    void Update()
    {
        RotateCamera();
        MovePlayer();
    }

    void RotateCamera()
    {
        // ----- CAMERA ROTATION ------
        // Add or subtract rotation based on where the
        // mouse is moving
        pitch -= Input.GetAxis("Mouse Y") * sensitivity;
        yaw += Input.GetAxis("Mouse X") * sensitivity;

        // NOTE: This does not prevent the camera from rotating around
        // completely in either direction. To fix that, use something
        // like Clamp, or use "if" statements to limit these values
        Vector3 targetPlayerRotation = new Vector3(0, yaw);
        playerTransform.eulerAngles = targetPlayerRotation;

        Vector3 targetCameraRotation = new Vector3(pitch, yaw);
        transform.eulerAngles = targetCameraRotation;
    }

    void MovePlayer()
    {
        float h = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float v = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        // Adding horizontal, vertical axes and "gravity"
        Vector3 vel = playerTransform.forward * v + playerTransform.right * h + Vector3.down;
        playerCharacterController.Move(vel);
    }
}