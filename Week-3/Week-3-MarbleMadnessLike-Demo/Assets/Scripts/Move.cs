using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle any inputs in the Update method
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;
        direction = new Vector3(h, 0, v);
        direction = Quaternion.Euler(0, 45, 0) * direction;
    }

    private void FixedUpdate()
    {
        // But apply any forces (or do other stuff with forces
        // or physics in the FixedUpdate)
        rb.AddForce(direction);
    }
}
