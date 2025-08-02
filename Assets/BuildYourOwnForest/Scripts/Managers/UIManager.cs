using Sirenix.OdinInspector;
using System;
using UnityEngine;

public class UIManager : Manager
{
    public static UIManager Instance { get; private set; }

    [TitleGroup("References")]
    [SerializeField] private StartUIWindow startUIWindow;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    public StartUIWindow ShowStartUIWindow(Location chosenLocation, Challenge chosenChallenge)
    {
        startUIWindow.enabled = true;
        startUIWindow.SetValues(chosenLocation.WorldLocation,chosenChallenge.Explanation, (int)chosenChallenge.GroundType.Attributes.x, (int)chosenChallenge.GroundType.Attributes.y, (int)chosenChallenge.GroundType.Attributes.z);
        return startUIWindow;
    }

}
