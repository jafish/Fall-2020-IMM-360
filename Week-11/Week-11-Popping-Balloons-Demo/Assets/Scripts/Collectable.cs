using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            other.GetComponent<PlayerController>().coinCount++;

            Destroy(transform.parent.gameObject);
        }
    }
}
