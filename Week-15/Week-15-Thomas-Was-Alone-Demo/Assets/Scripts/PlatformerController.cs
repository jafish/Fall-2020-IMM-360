using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerController : MonoBehaviour
{
    public int id = 0;

    [Tooltip("The speed of our player")]
    [Range(5,20)]
    public float speed = 1f;
    public float jumpForce = 5f;
    public LayerMask collisionMask;


    Rigidbody2D rb;
    bool active = false;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        //Only do movement stuff if this player is currently active
        if (active) 
        {
            //Get and apply horizontal movement
            float movement = Input.GetAxisRaw("Horizontal") * speed;
            rb.velocity = new Vector2(movement, rb.velocity.y);

            //Handle jumping

            if (Input.GetKeyDown(KeyCode.Space))
            {
                if (ControllerIsGrounded())
                {
                    rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                }
            }
        }
    }

    bool ControllerIsGrounded() 
    {
        Bounds b = GetComponent<BoxCollider2D>().bounds;
        Vector2 boxcastOrigin = new Vector2(transform.position.x, b.min.y);
        Vector2 boxcastSize = new Vector2(b.size.x, .05f);

        if(Physics2D.BoxCast(boxcastOrigin, boxcastSize, 0, Vector2.down, .05f, collisionMask)) 
        {
            return true;
        }

        return false;
    }

    public void ActivateCharacter() 
    {
        active = true;
        gameObject.layer = 0;
    }

    public void DeactivateCharacter() 
    {
        active = false;
        gameObject.layer = 8;
    }
}
