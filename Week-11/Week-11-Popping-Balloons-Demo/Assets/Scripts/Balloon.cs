using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [SerializeField] GameObject coin;

    bool popped = false;

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Projectile") 
        {
            if(popped == false)
            {
                for (int i = 0; i < 7; i++)
                {
                    Vector3 randomDirection = Random.onUnitSphere;
                    GameObject c = Instantiate(coin, transform.position + randomDirection, Quaternion.identity);
                    c.transform.up = randomDirection;

                    c.GetComponent<Rigidbody>().AddExplosionForce(3, transform.position, 1.5f, .75f, ForceMode.Impulse);
                }
                popped = true;
            }
            

            Destroy(this.gameObject);
        }
    }
}
