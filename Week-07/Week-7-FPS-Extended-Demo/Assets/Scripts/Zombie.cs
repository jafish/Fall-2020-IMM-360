using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Zombie : MonoBehaviour
{
    public Transform player;
    public NavMeshAgent agent;
    public int maxHP = 20;
    int currentHP;

    void Start()
    {
        currentHP = maxHP;     
    }

    void Update()
    {
        agent.SetDestination(player.position);        
    }

    public void OnHit()
    {
        currentHP--;

        if(currentHP <= 0) 
        {
            Destroy(gameObject);
        }
    }
}
