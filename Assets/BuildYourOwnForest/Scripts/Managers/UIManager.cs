using Sirenix.OdinInspector;
using System;
using UnityEngine;

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

    public void UpdateHUDValues(Attributes attributes) 
    { 
       hud.ValueContainer1.value.text = attributes.biodiversity.ToString();
       hud.ValueContainer2.value.text = attributes.soilQuality.ToString();
       hud.ValueContainer3.value.text = attributes.carbonStorage.ToString();
    }

    public void UpdateHUDTimer(int time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        hud.TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public StartUIWindow ShowStartUIWindow(Location chosenLocation, Challenge chosenChallenge)
    {
        startUIWindow.gameObject.SetActive(true);
        startUIWindow.SetValues(chosenLocation.WorldLocation,chosenChallenge.Explanation, chosenChallenge.GroundType.Attributes);
        return startUIWindow;
    }

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
