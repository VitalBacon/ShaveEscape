using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float mouseSensitivity = 0.3f;
    float yaw;
    float pitch;
    public Vector2 pitchLimits = new Vector2(-40, 85);

    public Transform anchor;
    public float anchorBackingOffset = 2f;

    void Start()
    {
        
    }

    void Update() {

        yaw += Input.GetAxis("Mouse X") * mouseSensitivity;
        pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity;

        pitch = Mathf.Clamp(pitch, pitchLimits.x, pitchLimits.y);

        Vector3 targetRotation = new Vector3(pitch, yaw);

        transform.eulerAngles = targetRotation;

        transform.position = anchor.position - transform.forward * anchorBackingOffset;
    }
}
