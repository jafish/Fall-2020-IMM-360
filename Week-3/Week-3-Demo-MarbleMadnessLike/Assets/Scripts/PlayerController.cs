using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate(new Vector3(Input.GetAxis("Horizontal")*Time.deltaTime, 0f, Input.GetAxis("Vertical") * Time.deltaTime));

        Vector3 direction = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        // For isometric controls
        direction = Quaternion.Euler(0, 45, 0) * direction;

        rb.AddForce(direction);
    }
}
