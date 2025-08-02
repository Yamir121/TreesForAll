using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Manager
{
    public static LevelManager Instance { get; private set; }
    private float levelLength => GameManager.Instance.LevelLength;

    [TitleGroup("High Level Objects")]
    [SerializeField] private WateringCan wateringCan;
    [SerializeField] private SelectionTable selectionTable;
    //[TitleGroup("Variables")]
    
    [TitleGroup("Data")]
    [ReadOnly][SerializeField] private GroundGrid activeGrid;
    [ReadOnly][SerializeField] private LevelInstance activeLevel;

    [Serializable]
    private class LevelInstance
    {
        public LevelInstance(Location location, Challenge challenge) 
        {
            this.location = location;
            this.challenge = challenge;
        }

        public Location location;
        public Challenge challenge;
    }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }


    public void StartLevelInstance(Location location, Challenge challenge)
    {
        //Get selectionObjects from the availableplants.
        var list = new List<Selectable>();
        for (int i = 0; i < location.AvailablePlants.Count; i++)
        {
          list.Add(location.AvailablePlants[i].SelectionObject);
        }
        list.Add(wateringCan);
        //Spawn the plants selection and watering can
        selectionTable.SpawnAndFillSelectionSlots(list);

        //Spawn the groundgrid
        activeGrid = Instantiate(challenge.GroundType.GroundGrid,transform.position,Quaternion.identity);
        activeGrid.SetGridSize((int)GameManager.Instance.GroundSize.x, (int)GameManager.Instance.GroundSize.y);
        activeGrid.PopulateGrid();
        activeLevel = new LevelInstance(location, challenge);
    }

    /// <summary>
    /// Spawn all available plant selections and the watering can.
    /// </summary>
    private bool SpawnSelectables(List<Plant> availablePlants)
    {
        for (int i = 0; i < availablePlants.Count; i++)
        {
            //.Add(Instantiate(availablePlants[i].SelectionObject));
        }
       // selectables.Add(Instantiate(wateringCan));
        //spawn in grid on table
        return true;
    }
}
