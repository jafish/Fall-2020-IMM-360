using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefab;
    public float timeToStart = 1f;
    public float repeatTimer = .5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObject", timeToStart, repeatTimer);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnObject() 
    {
        Instantiate(prefab, this.transform.position, Quaternion.identity);
        
    }
}
