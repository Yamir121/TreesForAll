using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Manager
{
    [TitleGroup("References")]
    [SerializeField] private WateringCan wateringCan;
    [SerializeField] private GroundType groundType;
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
            selectables.Add(Instantiate(availablePlants[i].SelectionObject));
        }
        selectables.Add(Instantiate(wateringCan));
        //spawn in grid on table
        return true;
    }
}
