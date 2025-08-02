using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Sirenix.OdinInspector;
using System.Threading;
using UnityEngine;

public class Holdable : MonoBehaviour
{
    [TitleGroup("Data")]
    public HandGrabInteractable GrabInteractable => grabInteractable;

    [TitleGroup("References")]
    [SerializeField] private HandGrabInteractable grabInteractable;

    private void OnEnable()
    {
        InteractionManager.Instance.RegisterHoldable(this);
    }

    public void Despawn()
    {
        //Spawn particle
        Destroy(this.gameObject);
    }
    private void OnDisable()
    {
        InteractionManager.Instance.UnregisterHoldable(this);
    }
}