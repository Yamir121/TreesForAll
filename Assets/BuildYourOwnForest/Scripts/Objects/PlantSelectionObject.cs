using Oculus.Interaction;
using Oculus.Interaction.HandGrab;
using Sirenix.OdinInspector;
using UnityEngine;
using static UnityEngine.XR.OpenXR.Features.Interactions.HandInteractionProfile;

//selectable plant object in scene
public class PlantSelectionObject : Selectable
{
    [TitleGroup("References")]
    [SerializeField] private Transform seedSpawnPosition;
    [SerializeField] private InformationWindow informationWindow;
    [TitleGroup("Data")]
    [InlineEditor(InlineEditorObjectFieldModes.Boxed)][SerializeField] private Plant plantData;
    public void Start()
    {
        //display data on a small UI
        informationWindow.SetValues(plantData.PlantName, plantData.IndigiousLocation.WorldLocation, (int)plantData.Attributes.x, (int)plantData.Attributes.y, (int)plantData.Attributes.z);
    }
    [Button]
    public override void Select(InteractionManager.InteractionType type, InteractionManager.Hand hand, Holdable holdable)
    {
        InteractionManager.Instance.SpawnTestCube(gameObject.transform.position + (Vector3.up * 2));
        if (type == InteractionManager.InteractionType.SELECT)
        InteractionManager.Instance.SpawnTestCube(gameObject.transform.position + (Vector3.up * 3));
        {
            Seed seed = Instantiate(plantData.SeedObject, seedSpawnPosition.position, seedSpawnPosition.rotation);
            // place seed in hand
            HandGrabInteractor interactor = hand == InteractionManager.Hand.LEFT ? InteractionManager.Instance.LeftHandInteractor : InteractionManager.Instance.RightHandInteractor;
            interactor.ForceSelect(seed.GrabInteractable);
        }
    }

}
