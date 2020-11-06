using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShot : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(transform.position, Vector3.up, 5f);
    }
}
