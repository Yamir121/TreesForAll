using Oculus.Interaction;
using Sirenix.OdinInspector;
using UnityEngine;

public class HeldObject : MonoBehaviour
{
    [TitleGroup("Data")]
    public GrabInteractable GrabInteractable => grabInteractable;

    [TitleGroup("References")]
    [SerializeField] private GrabInteractable grabInteractable;
}