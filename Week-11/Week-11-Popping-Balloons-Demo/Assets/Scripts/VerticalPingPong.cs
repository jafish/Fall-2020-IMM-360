using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPingPong : MonoBehaviour
{
    [SerializeField] float minY;
    [SerializeField] float maxY;
    [SerializeField] float speed;
    void Start()
    {
        
    }


    void Update()
    {
        //Move the balloon to the max to min y position, and back
        float yVal = Mathf.PingPong(Time.time * speed, maxY - minY) + minY;
        transform.position = new Vector3(transform.position.x, yVal, transform.position.z);
    }
}
