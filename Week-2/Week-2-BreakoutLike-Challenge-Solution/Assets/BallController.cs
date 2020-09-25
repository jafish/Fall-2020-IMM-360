using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody rb;
    int score;

    public GameObject paddle;

    bool gameActive = true;

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = new Vector3(-5f, -8f, 0f);

        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5.5) 
        {
            gameActive = false;
        }

        if (!gameActive) 
        {
            transform.position = paddle.transform.position + Vector3.up;

            if (Input.GetKeyDown(KeyCode.Space)) 
            {
                gameActive = true;
                rb.velocity = new Vector3(5f, 8f, 0f);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Block")
        {
            Destroy(collision.gameObject);
            score++;
            Debug.Log("Your score is : " + score);
        }
    }
}
