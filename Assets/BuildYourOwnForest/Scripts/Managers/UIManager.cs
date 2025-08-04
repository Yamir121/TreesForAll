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

    public void UpdateHUDValues(Vector3 values) 
    { 
       hud.ValueContainer1.value.text =  values.x.ToString();
       hud.ValueContainer2.value.text =  values.y.ToString();
       hud.ValueContainer3.value.text =  values.z.ToString();
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
        startUIWindow.SetValues(chosenLocation.WorldLocation,chosenChallenge.Explanation, (int)chosenChallenge.GroundType.Attributes.x, (int)chosenChallenge.GroundType.Attributes.y, (int)chosenChallenge.GroundType.Attributes.z);
        return startUIWindow;
    }

    public void HideStartUIWindow() 
    {  
        startUIWindow.gameObject.SetActive(false);
    }

}
