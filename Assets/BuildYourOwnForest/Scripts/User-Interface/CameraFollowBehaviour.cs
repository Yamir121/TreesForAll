using Sirenix.OdinInspector;
using UnityEngine;

/// <summary>
///Add this component to any gameobject and it will follow the main camera.
/// </summary>
public class CameraFollowBehaviour : MonoBehaviour
{
    [TitleGroup("References")]
    [SerializeField] private Transform trackedTransform;
    [TitleGroup("Settings")]
    [SerializeField] private float distanceFromHead = 2.0f;
    [SerializeField] private float heightOffset = 0.0f;
    [SerializeField] private float smoothTime = 0.3f;
    
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        //Get required position
        Vector3 targetPosition = trackedTransform.position + trackedTransform.forward * distanceFromHead;
        targetPosition.y += heightOffset;
        //Smooth damp effect to move slowly towards target
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        //Get the lookat direction
        Vector3 directionToCamera = transform.position - trackedTransform.position;
        if (directionToCamera != Vector3.zero)
        {
            //Look at the camera
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
