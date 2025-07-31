using Oculus.Interaction;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    [TitleGroup("References")]
    [SerializeField] private GrabInteractable grabInteractable;
    [SerializeField] private HeldObject heldObject;

    /// <summary>
    /// Called when object is enabled, subscribes to Meta's Interaction grab action
    /// </summary>
    private void OnEnable()
    {
        grabInteractable.WhenSelectingInteractorAdded.Action += OnSelected;
    }
    /// <summary>
    /// Called when object is grabbed, ungrabbing the object and selecting the replacement interactable. 
    /// </summary>
    /// <param name="interactor"> interactor given by event</param>
    private void OnSelected(GrabInteractor interactor)
    {
        interactor.Unselect();
        interactor.ForceSelect(heldObject.GrabInteractable);
    }
    /// <summary>
    /// Called when object is disabled, unsubscribes from Meta's Interaction grab action
    /// </summary>
    private void OnDisable()
    {
        grabInteractable.WhenSelectingInteractorAdded.Action -= OnSelected;

    }
}
