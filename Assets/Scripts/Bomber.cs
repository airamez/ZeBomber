using System;
using UnityEngine;

public class AirplaneController: MonoBehaviour
{
    public float FlySpeed = 5;
    public float MinAltitude = 5f;
    public float YawAmount = 60;
    private float smoothedHorizontalInput = 0f;
    private float Yaw;

    void Start()
    {
        
    }

    void Update()
    {
        // Move forward
        transform.position += transform.forward * FlySpeed * Time.deltaTime;

        // Ensure the airplane does not go below the ground level
        if (transform.position.y < MinAltitude)
        {
            transform.position = new Vector3(transform.position.x, MinAltitude, transform.position.z);
        }

        // Smooth the horizontal input
        float horizontalInput = Input.GetAxis("Horizontal");
        smoothedHorizontalInput = Mathf.Lerp(smoothedHorizontalInput, horizontalInput, Time.deltaTime * 5f);

        float verticalInput = Input.GetAxis("Vertical");

        // Yaw, pitch, roll
        Yaw += smoothedHorizontalInput * YawAmount * Time.deltaTime;
        float pitch = Mathf.Lerp(0, 20, Mathf.Abs(verticalInput)) * Mathf.Sign(verticalInput);
        float roll = Mathf.Lerp(0, 30, Mathf.Abs(smoothedHorizontalInput)) * -Mathf.Sign(smoothedHorizontalInput);

        // Apply smoothed rotation
        transform.localRotation = Quaternion.Lerp(
            transform.localRotation,
            Quaternion.Euler(Vector3.up * Yaw + Vector3.right * pitch + Vector3.forward * roll),
            Time.deltaTime * 5f // Adjust smoothing speed
        );
    }

}
