using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenEscape : StateMachineBehaviour
{
    private bool initialized = false;
    private Transform sheepTransform;
    private MovementManager movementManager;
    private ChickenController controller;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

        if (!initialized) {
            sheepTransform = GameObject.FindGameObjectWithTag("Sheep").transform;
            movementManager = animator.GetComponent<MovementManager>();
            controller = animator.GetComponent<ChickenController>();
            initialized = true;
        }

        movementManager.movementSpeed = controller.runSpeed;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        Vector3 sheepDirection = sheepTransform.position - animator.transform.position;
        if (sheepDirection.magnitude > controller.dangerRadius) {
            animator.SetTrigger("stop");
        }
        else {
            movementManager.movement = -sheepDirection;
        }
       
    }
}
