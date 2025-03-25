using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the airplane
    public float smoothSpeed = 0.125f; // Smoothing speed
    public Vector3 offset; // Offset from the target

    void LateUpdate()
    {
        // Desired camera position
        Vector3 desiredPosition = target.position + target.rotation * offset;

        // Smoothly interpolate camera's position
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

        // Maintain rotation to look at the airplane
        transform.LookAt(target);
    }
}
