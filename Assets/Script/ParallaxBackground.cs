using UnityEngine;

public class ParallaxBackground : MonoBehaviour
{
    [Header("Parallax Settings")]
    public float parallaxEffectMultiplier = 0.5f;  // Adjust this to control the parallax effect.
    
    private Transform cameraTransform;
    private Vector3 lastCameraPosition;

    private void Start()
    {
        cameraTransform = Camera.main.transform;
        lastCameraPosition = cameraTransform.position;
    }

    private void LateUpdate()
    {
        float deltaMovement = cameraTransform.position.x - lastCameraPosition.x;
        transform.position += new Vector3(deltaMovement * parallaxEffectMultiplier, 0, 0);
        lastCameraPosition = cameraTransform.position;
    }
}
