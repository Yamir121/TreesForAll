using Sirenix.OdinInspector;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{

    public float HighlightDistance => highlightDistance;
    public float InteractionDistance => interactionDistance;

    [TitleGroup("Settings")]
    [SerializeField] private float highlightDistance;
    [SerializeField] private float interactionDistance;
    [SerializeField] private InteractionManager.InteractionType[] acceptedInteractionTypes;
    [SerializeField] private float longSelectDuration;


    private void OnEnable()
    {
        InteractionManager.Instance.RegisterInteractionZone(this);
    }

    private void OnDisable()
    {
        InteractionManager.Instance.UnregisterInteractionZone(this);
    }

    private void OnDrawGizmosSelected()
    {
        // Draw the smaller sphere in green
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, highlightDistance);

        // Draw the larger sphere in red
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
}
