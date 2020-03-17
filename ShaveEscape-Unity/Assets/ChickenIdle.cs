using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenIdle : StateMachineBehaviour
{
    public float idleTime;
    private bool tickToggle = false;
    private bool actionTriggered;
    private float actionTimer;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        actionTimer = Random.Range(idleTime / 2f, idleTime);
        tickToggle = !tickToggle;
        actionTriggered = false;

        MovementManager movementManager = animator.GetComponent<MovementManager>();
        movementManager.movementSpeed = 0f;
    }

    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        actionTimer -= Time.deltaTime;

        if (actionTimer < 0 && !actionTriggered) {
            actionTriggered = true;
            TriggerAction(animator);
        }
    }

    void TriggerAction(Animator animator) {
        if (tickToggle) {
            animator.SetInteger("tickIndex", Random.Range(0, 4));
            animator.SetTrigger("tick");
        }

        else {
            animator.SetTrigger("walk");
        }
    }
}
