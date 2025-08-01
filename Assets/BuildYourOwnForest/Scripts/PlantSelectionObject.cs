using Oculus.Interaction;
using Sirenix.OdinInspector;
using UnityEngine;

//selectable plant object in scene
public class PlantSelectionObject : Selectable
{
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private Plant plantData;
    [SerializeField] private InformationWindow informationWindow;

    public void Start()
    {
        //display data on a small UI
        informationWindow.SetValues(plantData.PlantName, plantData.IndigiousLocation.WorldLocation, (int)plantData.Attributes.x, (int)plantData.Attributes.y, (int)plantData.Attributes.z);
    }
}
