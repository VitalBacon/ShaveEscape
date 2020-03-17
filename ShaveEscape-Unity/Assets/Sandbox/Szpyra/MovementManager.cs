using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public float movementSpeed;
    public float rotationSpeed = 0.2f;

    private Vector3 _movement;

    public Vector3 movement {
        get {
            return this._movement;
        }
        set {
            this._movement = value;
        }
    }

    // Start is called before the first frame update
    // void Start() {
    //     transform = GetComponent<Transform>();
    // }

    Vector3 GetMovementDirection() {
        return new Vector3(movement.x, 0, movement.z).normalized;
    }

    // Update is called once per frame
    void Update() {
        movement = GetMovementDirection();
        if (movement != Vector3.zero) {
            Quaternion targetRotation = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed);
        }
    }

    void FixedUpdate() {
        Move();
    }

    void Move() {
        if (movement != Vector3.zero) {
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
    }
}
