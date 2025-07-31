using Sirenix.OdinInspector;
using UnityEngine;

//selectable plant object in scene
public class SelectablePlant : Selectable
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private Plant plantData;
    //display data on a small UI
}
