using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    Rigidbody rb;
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody>();

        Vector3 forceDirection = new Vector3(Random.Range(-10, 10), Random.Range(0, 20), 0);

        rb.AddForce(forceDirection, ForceMode.Impulse);
    }

}
