using Oculus.Interaction;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(InteractionZone))]
public abstract class Selectable : MonoBehaviour
{
    [SerializeField] private InteractionZone interactionZone;

    private void OnEnable()
    {
        interactionZone.Interact += Select;
    }

    public abstract void Select(InteractionManager.InteractionType type, InteractionManager.Hand hand, Holdable holdable);

    private void OnDisable()
    {
        interactionZone.Interact += Select;
    }
}
