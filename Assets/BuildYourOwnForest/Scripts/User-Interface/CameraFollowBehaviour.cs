using Sirenix.OdinInspector;
using UnityEngine;

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
        Vector3 targetPosition = trackedTransform.position + trackedTransform.forward * distanceFromHead;
        targetPosition.y += heightOffset;

        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        Vector3 directionToCamera = transform.position - trackedTransform.position;
        if (directionToCamera != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(directionToCamera);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
        }
    }
}
