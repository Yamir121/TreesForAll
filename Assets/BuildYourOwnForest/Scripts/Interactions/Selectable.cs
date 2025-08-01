using Oculus.Interaction;
using Sirenix.OdinInspector;
using UnityEngine;

[RequireComponent(typeof(InteractionZone))]
public class Selectable : MonoBehaviour
{
    [SerializeField] private InteractionZone interactionZone;
}
