using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public int id = 0;
    public bool doorEntered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlatformerController collidedController = collision.GetComponent<PlatformerController>();

        if(collidedController != null) 
        {
            if(collidedController.id == id) 
            {
                doorEntered = true;
                GetComponent<SpriteRenderer>().color = Color.green;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlatformerController collidedController = collision.GetComponent<PlatformerController>();

        if (collidedController != null)
        {
            if (collidedController.id == id)
            {
                doorEntered = false;
                GetComponent<SpriteRenderer>().color = Color.white;
            }
        }
    }
}
