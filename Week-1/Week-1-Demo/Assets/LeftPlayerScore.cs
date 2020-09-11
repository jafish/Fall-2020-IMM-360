using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftPlayerScore : MonoBehaviour
{
    int leftScore;
    // Start is called before the first frame update
    void Start()
    {
        leftScore = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Assume that just the ball will hit me
        leftScore += 1;
        Debug.Log(leftScore);
    }
}
