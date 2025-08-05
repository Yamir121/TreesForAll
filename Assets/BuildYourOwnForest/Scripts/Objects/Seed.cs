using Sirenix.OdinInspector;
using UnityEngine;

public class Seed : Holdable
{
    public Plant PlantData => plantData;
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private Plant plantData;
}
