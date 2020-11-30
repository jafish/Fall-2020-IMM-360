using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector2 = UnityEngine.Vector2;

public class PlayerControllerDemo : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 forceToApply;
    public float forceMultiplier;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    void Update()
    {
        forceToApply = Input.GetAxisRaw("Horizontal") * Vector2.right * forceMultiplier;
    }

    void FixedUpdate()
    {
        rb.AddForce(forceToApply, ForceMode2D.Force);
    }
    
}
