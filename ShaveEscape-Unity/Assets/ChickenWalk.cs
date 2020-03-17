using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenWalk : StateMachineBehaviour
{
    private float sqrDistanceEpsilon = 0.4f;

    private bool initialized = false;
    private MovementManager movementManager;
    private ChickenController controller;

    private Vector3 destination;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (!initialized) {
            movementManager = animator.GetComponent<MovementManager>();
            controller = animator.GetComponent<ChickenController>();
            initialized = true;
        }

        Vector3 randomDir = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;
        float randomRadius = Random.Range(0f, controller.wanderRadius);
        
        destination = controller.origin + randomDir * randomRadius;

        movementManager.movementSpeed = controller.walkSpeed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Vector3 destinationDir = destination - animator.transform.position;
        if (destinationDir.sqrMagnitude < sqrDistanceEpsilon) {
            animator.SetTrigger("stop");
        }
        else {
            movementManager.movement = destinationDir;
        }
       
    }
}
