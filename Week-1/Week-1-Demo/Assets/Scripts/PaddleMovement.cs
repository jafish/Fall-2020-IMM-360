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
        if (Input.GetKey(upKey))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(downKey))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        //Debug.Log(Time.deltaTime);
    }
}
