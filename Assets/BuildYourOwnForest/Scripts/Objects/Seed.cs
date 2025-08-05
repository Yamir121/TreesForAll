using Sirenix.OdinInspector;
using UnityEngine;

//Holdable object storing the seed information needed for seeds to be planted. 
public class Seed : Holdable
{
    public Plant PlantData => plantData;
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private Plant plantData;
}
