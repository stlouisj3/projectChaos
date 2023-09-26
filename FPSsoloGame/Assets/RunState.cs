using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RunState : StateMachineBehaviour
{

    
    private NavMeshAgent agent;

    
    private Transform player;

    [SerializeField]
    private float moveDistance = 15f;


    [SerializeField]
    private float attackDistance = 2f;
    

    private float dis;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
   {
        agent = animator.GetComponent<NavMeshAgent>();
        if(agent == null)
            agent = animator.GetComponentInParent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(agent != null) { 
        dis = Vector3.Distance(player.position, animator.transform.position);
        agent.isStopped = false;
        agent.SetDestination(player.position);
        if (attackDistance > dis) //Attack
        {
            
            animator.SetBool("Attack", true);
            animator.SetBool("Run", false);
            agent.isStopped = true;
        }
        else if(dis > moveDistance) //Idle
        {
            animator.SetBool("Idle", true);
            animator.SetBool("Run", false);
            agent.isStopped = true;
        }


       }





    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that processes and affects root motion
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Implement code that sets up animation IK (inverse kinematics)
    }
}
