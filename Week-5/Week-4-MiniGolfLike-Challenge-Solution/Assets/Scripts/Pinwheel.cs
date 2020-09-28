using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinwheel : MonoBehaviour
{
    public float speed;
    public GameObject paddle1;
    public GameObject paddle2;

    Vector3 pivot;
    void Start()
    {
        pivot = (paddle1.transform.position + paddle2.transform.position) / 2;
    }

    // Update is called once per frame
    void Update()
    {
        paddle1.transform.RotateAround(pivot, Vector3.up, speed);
        paddle2.transform.RotateAround(pivot, Vector3.up, speed);
    }
}
