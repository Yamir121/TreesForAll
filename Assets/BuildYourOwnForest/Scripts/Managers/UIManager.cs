using Sirenix.OdinInspector;
using System;
using UnityEngine;

//Manages all UI in the game, reports to the game manager.
public class UIManager : Manager
{
    public static UIManager Instance { get; private set; }

    [TitleGroup("References")]
    [SerializeField] private StartUIWindow startUIWindow;
    [SerializeField] private HUD hud;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    /// <summary>
    /// Updates visible attribute values to realtime values.
    /// </summary>
    /// <param name="attributes">Values to update to.</param>
    public void UpdateHUDValues(Attributes attributes) 
    { 
       hud.ValueContainer1.value.text = attributes.biodiversity.ToString();
       hud.ValueContainer2.value.text = attributes.soilQuality.ToString();
       hud.ValueContainer3.value.text = attributes.carbonStorage.ToString();
    }

    /// <summary>
    /// Updates hud timer.
    /// </summary>
    /// <param name="time">Time to update the timer to.</param>
    public void UpdateHUDTimer(int time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        hud.TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    /// <summary>
    /// Enables the start window.
    /// </summary>
    /// <param name="chosenLocation">location to show</param>
    /// <param name="chosenChallenge">challenge to show</param>
    /// <returns></returns>
    public StartUIWindow ShowStartUIWindow(Location chosenLocation, Challenge chosenChallenge)
    {
        startUIWindow.gameObject.SetActive(true);
        startUIWindow.SetValues(chosenLocation.WorldLocation,chosenChallenge.Explanation, chosenChallenge.GroundType.Attributes);
        return startUIWindow;
    }

    /// <summary>
    /// Hides start window
    /// </summary>
    public void HideStartUIWindow() 
    {  
        startUIWindow.gameObject.SetActive(false);
    }

    public void ShowHUD()
    {
        hud.gameObject.SetActive(true); 
    }

    public void HideHUD()
    {
        hud.gameObject.SetActive(false);
    }

}
