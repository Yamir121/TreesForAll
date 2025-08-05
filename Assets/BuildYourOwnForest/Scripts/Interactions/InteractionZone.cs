using Oculus.Interaction.HandGrab;
using Oculus.Interaction.Input;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InteractionZone : MonoBehaviour
{

    public float InteractionDistance => interactionDistance;
    public float HighlightDistance => highlightDistance;
    public bool IsHighlighting => isHighlighting;

    public InteractionManager.InteractionType[] AcceptedInteractionTypes => acceptedInteractionTypes;

    public Action<InteractionManager.InteractionType,InteractionManager.Hand, Holdable> Interact;

    [TitleGroup("References")]
    [SerializeField] private Renderer highlightVisual;

    [TitleGroup("Settings")]
    [SerializeField] private float interactionDistance;
    [SerializeField] private float highlightDistance;
    [SerializeField] private int priority; //when two interactionzones overlap, one should get priority over the other
    [SerializeField] private InteractionManager.InteractionType[] acceptedInteractionTypes;
    [SerializeField] private float longSelectDuration;

    [TitleGroup("Data")]
    [ReadOnly][SerializeField] private bool isHighlighting = false;

    private void OnEnable()
    {
        InteractionManager.Instance.RegisterInteractionZone(this);
    }

    public void UpdateHighlight(float distance, bool validInteraction)
    {
        if (highlightVisual != null)
        {
                //Clamp the dinstance in reverse between 1 and 0 to get a visual intensity.
                float intensity = 1f - ((distance - interactionDistance) / (highlightDistance - interactionDistance));

                //This code is temporary until I've found a shader to use as highlight visual
                highlightVisual.material.SetFloat("_Smoothness", (intensity * 0.5f));
                highlightVisual.material.color = new Color(highlightVisual.material.color.r, highlightVisual.material.color.g, highlightVisual.material.color.b, intensity);
        }
    }

    public void ResetHighlight()
    {
        if (highlightVisual != null)
        {
            highlightVisual.material.SetFloat("_Smoothness", (0f));
            highlightVisual.material.color = new Color(highlightVisual.material.color.r, highlightVisual.material.color.g, highlightVisual.material.color.b, 0f);
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
