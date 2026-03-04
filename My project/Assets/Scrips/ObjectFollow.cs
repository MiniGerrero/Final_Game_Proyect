 using UnityEngine;

public class CameraFollow2D : MonoBehaviour
{
    public Transform target; // The object for the camera to follow
    public float followSpeed = 5f; //How quickly the camera follows
    public Vector2 offset = Vector2.zero; // How far the camera can be from the object/player

    void LateUpdate()
    {
        // Only run if there is a target assigned
        if (target != null)
        {
            // Target position with offset, keep z the same (-10)
            Vector3 desiredPosition = new Vector3(
                target.position.x + offset.x,
                target.position.y + offset.y,
                transform.position.z
            );

            // Interpolate between current and desired position
            transform.position = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
        }
    }
}
