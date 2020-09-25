using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject focus;
    
    public GameObject club;
    public float clubSwingAngle = 150;

    public Vector3 hitBoxOffset;
    public float hitBoxRadius = 1;

    public float maxHitPower;
    public float minHitPower;
    float swingDirection = 1;

    float score = 0;
    float bestScore = Mathf.Infinity;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calculate player position based on the position of the mouse and camera.
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9);
        Vector3 nextPlayerPos = Camera.main.ScreenToWorldPoint(mousePos);
        transform.position = nextPlayerPos;

        //Calculate the direction the player should face based on the direction between them and the focused GameObject
        Vector3 focusPoint = new Vector3(focus.transform.position.x, transform.position.y, focus.transform.position.z);
        //Vector3 directionToFocus = (focusPoint - transform.position);
        transform.LookAt(focusPoint);

        //Handle Input
        if (Input.GetMouseButtonDown(0)) 
        {
            SwingClub();
        }
    }

    private void SwingClub()
    {
        //Visual Swing
        club.transform.RotateAround(transform.position, Vector3.up, clubSwingAngle * swingDirection);
        swingDirection *= -1;

        //Swing Logic
        score++;

        Collider[] hits = Physics.OverlapSphere(transform.position + transform.forward + hitBoxOffset, hitBoxRadius);

        foreach(Collider hit in hits) 
        {
            if(hit.gameObject.tag == "Ball") 
            {
                Rigidbody ball = hit.gameObject.GetComponent<Rigidbody>();

                Vector3 hitOrigin = new Vector3(transform.position.x, hit.transform.position.y, transform.position.z);
                Vector3 hitDirection = (hit.transform.position - hitOrigin).normalized;
                float hitDistance = Vector3.Distance(hitOrigin, hit.transform.position);

                float power = Mathf.Lerp(minHitPower, maxHitPower, 1 - (hitDistance/(2*hitBoxRadius)));
                
                ball.AddForce(hitDirection * power, ForceMode.Impulse);
            }
        }
    }

    public void Reset()
    {
        transform.position = new Vector3(0, 1, -3);

        Debug.Log("This hole took you " + score + " swings.");

        if (score < bestScore)
        {
            bestScore = score;
            Debug.Log("You got a new High Score!");
        }
        else
        {
            Debug.Log("The High Score is " + bestScore);
        }

        score = 0;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + transform.forward + hitBoxOffset, hitBoxRadius);

    }


}
