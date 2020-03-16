using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepMovement : MonoBehaviour
{
    private Rigidbody rb;
    public Camera camera;

    public float runSpeed = 5f;
    public float movementSpeed = 1000f;
    private Vector3 movement = Vector3.zero;

    public float rotationSpeed = 0.2f;

    public Animator animator;

    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    Vector3 GetInputDirection() {
        return new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
    }

    Vector3 GetMovementDirection() {
        Vector3 direction3D = camera.transform.rotation * GetInputDirection();
        return new Vector3(direction3D.x, 0, direction3D.z).normalized;
    }

    // Update is called once per frame
    void Update() {
        movement = GetMovementDirection();
        if (movement != Vector3.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            rb.transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
        }

        if (Input.GetKeyDown("space")) {
            rb.transform.position = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
    }

    void FixedUpdate() {
        Move();
    }

    private void Move() {
        if (movement != Vector3.zero) {
            rb.transform.Translate(Vector3.forward * runSpeed * Time.deltaTime);
        }
        
        float animatorRunSpeed = (movement != Vector3.zero) ? 1 : 0;
        animator.SetFloat("maxSpeedFraction", animatorRunSpeed);
    }
}
