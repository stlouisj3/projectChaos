using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CactusNavMesh : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    GameObject player;
    void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
    }

    private void Update()
    {
       agent.SetDestination(player.transform.position); 
    }
}
