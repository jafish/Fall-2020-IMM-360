using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject focus;
    public float smoothing = 2f;
    Vector3 offset;
    Vector3 v;
    void Start()
    {
        offset = new Vector3(0, transform.position.y, 0);
    }

    void Update()
    {
        Vector3 nextCameraPos = Vector3.SmoothDamp(transform.position, focus.transform.position + offset, ref v, smoothing);

        transform.position = nextCameraPos;        
    }
}
