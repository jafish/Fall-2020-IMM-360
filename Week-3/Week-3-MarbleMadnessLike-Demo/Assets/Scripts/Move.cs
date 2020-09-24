using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private Vector3 direction;
    private Vector3 homePosition;
    public Vector3 lastCheckpointPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = Vector3.zero;
        homePosition = transform.position;
        lastCheckpointPosition = homePosition;
    }

    // Update is called once per frame
    void Update()
    {
        // Handle any inputs in the Update method
        float h = Input.GetAxis("Horizontal") * speed;
        float v = Input.GetAxis("Vertical") * speed;
        direction = new Vector3(h, 0, v);
        direction = Quaternion.Euler(0, 45, 0) * direction;

        if (transform.position.y < -4)
        {
            // Quick Game Reset
            Debug.Log("You lost");

            Reset();
        }
    }

    private void FixedUpdate()
    {
        // But apply any forces (or do other stuff with forces
        // or physics in the FixedUpdate)
        rb.AddForce(direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "End")
        {
            Debug.Log("You Won");
            Reset();
        }
    }

    private void Reset()
    {
        transform.position = lastCheckpointPosition;
        rb.velocity = Vector3.zero;
        rb.rotation = Quaternion.identity;
        // TODO how to just zero out the whole rb
    }
}
