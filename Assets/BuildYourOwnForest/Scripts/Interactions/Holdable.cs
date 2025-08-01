using Oculus.Interaction;
using Sirenix.OdinInspector;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    [TitleGroup("Data")]
    public GrabInteractable GrabInteractable => grabInteractable;

    [TitleGroup("References")]
    [SerializeField] private GrabInteractable grabInteractable;

    private void OnEnable()
    {
        InteractionManager.Instance.RegisterHoldable(this);
    }

    private void OnDisable()
    {
        InteractionManager.Instance.UnregisterHoldable(this);
    }
}