using Meta.XR.ImmersiveDebugger.UserInterface;
using Sirenix.OdinInspector;
using System;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Manager
{
    public static LevelManager Instance { get; private set; }
    private float levelLength => GameManager.Instance.LevelLength;

    [TitleGroup("High Level Objects")]
    [SerializeField] private Selectable wateringCanSelectionObject;
    [SerializeField] private SelectionTable selectionTable;
    //[TitleGroup("Variables")]
    
    [TitleGroup("Data")]
    [ReadOnly][SerializeField] private GroundGrid activeGrid;
    [ReadOnly][SerializeField] private LevelInstance currentLevel;
    [ReadOnly][SerializeField] private TimeManager.Timer activelevelTimer;

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
        public int timeElapsed;
        public bool isActive;
        public Attributes realTimeAttributes;
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

    private void Update()
    {
        if (currentLevel.isActive) 
        {
            LevelUpdate();
        }
    }

    public void StartLevelInstance(Location location, Challenge challenge)
    {
        //Get selectionObjects from the availableplants.
        var list = new List<Selectable>();
        list.Add(wateringCanSelectionObject);
        for (int i = 0; i < location.AvailablePlants.Count; i++)
        {
          list.Add(location.AvailablePlants[i].SelectionObject);
        }
        //Spawn the plants selection and watering can
        selectionTable.SpawnAndFillSelectionSlots(list);

        //Spawn the groundgrid
        activeGrid = Instantiate(challenge.GroundType.GroundGrid,transform.position,Quaternion.identity);
        activeGrid.SetGridSize((int)GameManager.Instance.GroundSize.x, (int)GameManager.Instance.GroundSize.y);
        activeGrid.PopulateGrid();
        UIManager.Instance.ShowHUD();
        activelevelTimer = TimeManager.Instance.StartTimer(levelLength,true, EndLevelInstance);
        currentLevel = new LevelInstance(location, challenge);
        currentLevel.realTimeAttributes = challenge.GroundType.Attributes;
        currentLevel.isActive = true;
    }

    private void LevelUpdate()
    {
        if (currentLevel.timeElapsed != (int)activelevelTimer.GetCurrentTime())
        {
            UIManager.Instance.UpdateHUDTimer((int)activelevelTimer.GetCurrentTime());
        }

        activeGrid.UpdateAllOccupyingObjects();
    }


    public void EndLevelInstance()
    {
        UIManager.Instance.HideHUD();
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
