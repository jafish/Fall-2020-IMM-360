using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPingPong : MonoBehaviour
{
    [SerializeField] private float minY;
    [SerializeField] private float maxY;
    public float speed;
    [SerializeField] private float currentYPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the balloon from the max to min y position, and back
        currentYPos = minY + Mathf.PingPong(Time.time*speed, maxY-minY);
        transform.position = new Vector3(transform.position.x, currentYPos, transform.position.z);
    }
}
