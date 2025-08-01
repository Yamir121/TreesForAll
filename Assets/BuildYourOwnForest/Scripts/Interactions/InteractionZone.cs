using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{

    public float HighlightDistance => highlightDistance;
    public float InteractionDistance => interactionDistance;
    public bool IsHighlighting => isHighlighting;

    public InteractionManager.InteractionType[] AcceptedInteractionTypes => acceptedInteractionTypes;

    public Action<InteractionManager.InteractionType,InteractionManager.Hand> Interact;

    [TitleGroup("References")]
    [SerializeField] private Renderer highlightVisual;

    [TitleGroup("Settings")]
    [SerializeField] private float highlightDistance;
    [SerializeField] private float interactionDistance;
    [SerializeField] private int priority; //when two interactionzones overlap, one should get priority over the other
    [SerializeField] private InteractionManager.InteractionType[] acceptedInteractionTypes;
    [SerializeField] private float longSelectDuration;

    [TitleGroup("Data")]
    [ReadOnly][SerializeField] private bool isHighlighting = false;

    private void OnEnable()
    {
        Debug.Log(InteractionManager.Instance);
        InteractionManager.Instance.RegisterInteractionZone(this);
    }

    public void UpdateHighlight(float distance)
    {
        if (highlightVisual != null)
        {
            float intensity = 1f - ((distance - interactionDistance) / (highlightDistance - interactionDistance));
            highlightVisual.material.color = new Color(highlightVisual.material.color.r, highlightVisual.material.color.g, highlightVisual.material.color.b, intensity);
        }
    }

    private void OnDisable()
    {
        InteractionManager.Instance.UnregisterInteractionZone(this);
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, highlightDistance);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }
#endif
}
