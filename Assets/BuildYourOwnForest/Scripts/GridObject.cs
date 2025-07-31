using Sirenix.OdinInspector;
using UnityEngine;

//Plant object in the ground grid such as trees and shrubbery.
public class GridObject : MonoBehaviour
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private Plant plantData;
    [SerializeField] private HeldObjectReleaseZone releaseZone;

}
