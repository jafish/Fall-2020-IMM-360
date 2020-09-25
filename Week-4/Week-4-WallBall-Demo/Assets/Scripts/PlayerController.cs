using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 maxBounds;
    public Vector2 minBounds;

    public GameObject paddle;

    public float swingAngle = 60;

    public float hitRadius = 1;

    float direction = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 9);
        Vector3 nextPlayerPosition = Camera.main.ScreenToWorldPoint(mousePos);

        float clampedX = Mathf.Clamp(nextPlayerPosition.x, minBounds.x, maxBounds.x);
        float clampedZ = Mathf.Clamp(nextPlayerPosition.z, minBounds.y, maxBounds.y);
        Vector3 clampedPlayerPosition = new Vector3(clampedX, nextPlayerPosition.y, clampedZ);

        transform.position = clampedPlayerPosition;

        if (Input.GetMouseButtonDown(0)) 
        {
            SwingPaddle();
        }
    }

    void SwingPaddle() 
    {
        paddle.transform.RotateAround(transform.position, Vector3.up, swingAngle * direction);
        direction *= -1;
        
        Collider[] hits = Physics.OverlapSphere(transform.position + (transform.forward * hitRadius), hitRadius);
        
        foreach (Collider col in hits) 
        {
            Debug.Log(col.gameObject.tag);
            if(col.gameObject.tag == "Ball") 
            {
                Rigidbody ball = col.gameObject.GetComponent<Rigidbody>();

                Vector3 directionToBall = (col.gameObject.transform.position - transform.position).normalized;

                ball.velocity = directionToBall * 5;
            }        
        }
        
    }
}
