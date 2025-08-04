using Oculus.Interaction.HandGrab;
using System;
using UnityEngine;

public class EmptyGridSpace : MonoBehaviour
{
    public InteractionZone InteractionZone => zone;
    public GroundGrid.GridSpace gridSpace;
    [SerializeField] private InteractionZone zone;
    

    private void OnEnable()
    {
        zone.Interact += FillSpace;
    }

    private void FillSpace(InteractionManager.InteractionType type, InteractionManager.Hand hand, Holdable holdable)
    {
        if (holdable is Seed)
        {
            //Spawn plant
        }
    }


}
