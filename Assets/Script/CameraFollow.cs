using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // The player object's transform
    public float smoothSpeed = 0.125f; // The speed at which the camera follows the player
    public Vector3 offset; // Offset from the player

    void LateUpdate()
{
    if(target != null)
    {
        Vector3 desiredPosition = target.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}

}
