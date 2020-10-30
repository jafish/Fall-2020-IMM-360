using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour
{
    public GameObject player;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Ball")
        {
            other.GetComponent<Rigidbody>().velocity = Vector3.zero;
            other.transform.position = new Vector3(0, .25f, 0);

            player.GetComponent<PlayerController>().Reset();
        }
    }
}
