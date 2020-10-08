using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    public void OnHit() 
    {
        Debug.Log("Ouch!");
        Destroy(gameObject);

    }
}
