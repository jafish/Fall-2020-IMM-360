using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    private Vector2 forceToApply;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the force we want to apply based on keypress
        forceToApply = Input.GetAxisRaw("Horizontal") * Vector2.right * 50;
    }

    private void FixedUpdate()
    {
        rb.AddForce(forceToApply, ForceMode2D.Force);
    }
}
