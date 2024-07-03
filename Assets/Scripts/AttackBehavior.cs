using System.Collections;
using System.Collections.Generic;
// using UnityEngine.SceneManagement;
using UnityEngine;
public class AttackBehavior : StateMachineBehaviour
{
    
    Transform player;
    PlayerMovement playerMovement;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.LookAt(player);
        float distance = Vector3.Distance(animator.transform.position, player.position);
        if(distance >= 5){
            animator.SetBool("isAttacking", false);
        }
        
        // else {
            //play get hit animation
            // animator.SetTrigger("damage");
            // return;
        // }

        // playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        // playerMovement.TakeDamage(30);        
        playerMovement = GameObject.FindObjectOfType<PlayerMovement>();
        Debug.Log(30/60);
        playerMovement.TakeDamage(30/60);        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
