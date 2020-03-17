using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChickenController : MonoBehaviour
{
    Animator animator;
    MovementManager movementManager;
    public Vector3 origin { get; private set; }
    public float wanderRadius = 3f;
    public float dangerRadius = 3f;

    public float walkSpeed = 1f;
    public float runSpeed = 5f;

    private Transform sheepTransform;

    // Start is called before the first frame update
    void Start() {
        animator = GetComponent<Animator>();
        movementManager = GetComponent<MovementManager>();
        origin = transform.position;
        sheepTransform = GameObject.FindGameObjectWithTag("Sheep").transform;
    }

    // Update is called once per frame
    void Update() {
        if (IsInDanger()) {
            animator.SetTrigger("escape");
        }
    }

    private bool IsInDanger() {
        return (sheepTransform.position - transform.position).sqrMagnitude < dangerRadius * dangerRadius;
    }
}
