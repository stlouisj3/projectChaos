using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent agent;

    [SerializeField]
    private Transform player;

    [SerializeField]
    private float moveDistance = 15f;
    [SerializeField]
    private float attackDistance = 2f;
    private float speed = 10f;

    private float dis;

    [SerializeField]
    private animationController mations;

    // Start is called before the first frame update
    void OnEnable()
    {
        mations.setAttack(false);

    }

    // Update is called once per frame
    void Update()
    {
        
        dis = Vector3.Distance(player.position, this.transform.position);
        
        if (attackDistance < dis && dis < moveDistance) //Enemy is Moving
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
            mations.setRun(true);
            mations.setIdle(false);
            
        }

        else
        {
            
            agent.isStopped = true;
            mations.setRun(false);
            
            if (attackDistance > dis)
            {
                
                mations.setAttack(true);
            }
            else
            {
                mations.setIdle(true);
            }
            


        }
    }
}
