using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 5f;
    public KeyCode upKey;
    public KeyCode downKey;

 
    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        //transform.Translate(Input.GetAxis("Vertical") * Vector3.up * speed * Time.deltaTime);

        if (Input.GetKey(upKey))
        {
            // Time.deltaTime is the amount of time that has passed between the current
            // frame and previous frame
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(downKey))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
    }
}
