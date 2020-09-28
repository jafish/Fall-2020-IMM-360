using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 5;

    void Start()
    {
        
    }


    void Update()
    {
        float hMove = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * speed * Time.deltaTime * hMove);
    }

    
}
