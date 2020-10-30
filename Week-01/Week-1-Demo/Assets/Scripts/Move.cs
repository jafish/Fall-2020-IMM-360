using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform refers to the transform component that
        // is attached to this game object
        // Translate is a function that is a part of the Transform class
        // Vector3.left is a built-in property of the Vector
        // Vector3.left is the same thing as new Vector3(-1, 0, 0);
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.Translate(new Vector3(-1, 0, 0));
        }
    }
}
