using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float range = 30;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        {
            Fire();
        }    
    }

    void Fire() 
    {
        Ray ray = new Ray(transform.position + transform.forward, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range)) 
        {
            Target t = hit.collider.GetComponent<Target>();

            if (t != null) 
            {
                t.OnHit();
            }
        }
    }
}
