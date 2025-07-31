using Oculus.Interaction;
using Oculus.Interaction.Demo;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

///Meta handles grab logic, such as position and rotation, handposes release behaviour. I choose this route to support both handtracking and controller tracking for intiutive interactions.
public class InteractionManager : Manager
{
    [TitleGroup("References")]
    [SerializeField] private WateringCan wateringCan;
    [TitleGroup("Variables")]
    [TitleGroup("Data")]
    [SerializeField] private List<Selectable> selectables;

    /// <summary>
    /// Spawn all available plant selections and the watering can.
    /// </summary>
    public bool SpawnSelectables(List<Plant> availablePlants) 
    {
        for (int i = 0; i < availablePlants.Count; i++) 
        {
            selectables.Add(Instantiate(availablePlants[i].SelectionPrefab)); 
        }
        selectables.Add(Instantiate(wateringCan));
        //spawn in grid on table
        return true;
    }
}