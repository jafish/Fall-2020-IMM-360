using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRightMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Detects left and right arrows automatically through the axis
        transform.Translate(new Vector3(Input.GetAxis("Horizontal"), 0, 0));


        // Left Arrow to move left
        //if (Input.GetKey(KeyCode.LeftArrow))
        //{
        //    transform.Translate(Vector3.left);
        //}

        //// Right Arrow to move right
        //if (Input.GetKey(KeyCode.RightArrow))
        //{
        //    transform.Translate(Vector3.right);
        //}
    }
}
