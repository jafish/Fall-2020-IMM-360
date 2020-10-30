using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    void Start()
    {
        Destroy(gameObject, 5);    
    }
    private void OnCollisionEnter(Collision collision)
    {
        Zombie hitTarget = collision.gameObject.GetComponent<Zombie>();

        if (hitTarget) 
        {
            hitTarget.OnHit();
        }

        Destroy(gameObject);
    }
}
