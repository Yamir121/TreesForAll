using Oculus.Interaction.HandGrab;
using Sirenix.OdinInspector;
using System;
using UnityEngine;

//Space in the grid which can be interacted with to fill the gridspace, managed by the groundgrid and therefore by the levelmanager.
public class EmptyGridSpace : MonoBehaviour
{
    public InteractionZone InteractionZone => zone;
    [TitleGroup("References")]
    [SerializeField] private InteractionZone zone;
    [TitleGroup("Data")]
    public GroundGrid.GridSpace gridSpace;
    
    
    private void OnEnable()
    {
        zone.Interact += FillSpace;
    }

    private void FillSpace(InteractionManager.InteractionType type, InteractionManager.Hand hand, Holdable holdable)
    {
        if (type == InteractionManager.InteractionType.USE && holdable is Seed)
        {
            Seed seed = (Seed)holdable;
            gridSpace.occupyingObject = Instantiate(seed.PlantData.GridObject, new Vector3(gridSpace.position.x, gridSpace.position.y, gridSpace.position.z), Quaternion.identity, this.transform);
            TimeManager.Instance.StartTimer(1, false, Destroy);
        }
    }

    private void OnDisable()
    {
        zone.Interact -= FillSpace;
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }
}
