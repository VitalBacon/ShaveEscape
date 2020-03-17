using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    public float startingTimer;
    float actionTimer;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       actionTimer = startingTimer;
       Debug.Log("XDD chuj");
       animator.SetBool("shouldTick", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
       actionTimer -= Time.deltaTime;

       if (actionTimer < 0) {
           TriggerAction(animator);
       }
    }

    void TriggerAction(Animator animator) {
        bool shouldTick = animator.GetBool("shouldTick");
        Debug.Log("kurrrva");

        if (shouldTick) {

            int tickIndex = Random.Range(0, 4);

            animator.SetInteger("tickIndex", tickIndex);
            // animator.SetBool("shouldTick", false);
            animator.SetTrigger("tick");
            actionTimer = startingTimer;
        }
        
        else {
            animator.SetTrigger("endIdle");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Debug.Log("no i elo");
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
