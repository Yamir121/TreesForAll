using Meta.XR.ImmersiveDebugger.UserInterface.Generic;
using Oculus.Interaction;
using Sirenix.OdinInspector;
using System;
using TMPro;
using UnityEngine;

public class StartUIWindow : InteractableUIWindow
{

    public bool ButtonPressed => buttonPressed;

    [TitleGroup("References")]
    [SerializeField] private TMP_Text locationText;
    [SerializeField] private TMP_Text challengeText;
    [SerializeField] private TMP_Text startingCarbonStorageValue;
    [SerializeField] private TMP_Text startingBiodiversityValue;
    [SerializeField] private TMP_Text startingSoilQualityValue;
    [SerializeField] private PokeInteractable buttonInteractable;
    [TitleGroup("Data")]
    [SerializeField] private bool buttonPressed;

    public void OnEnable()
    {
        buttonInteractable.WhenPointerEventRaised += OnClick;
    }

    private void OnClick(PointerEvent pointerEvent)
    {
        buttonPressed = true;
    }

    public void SetValues(string location, string challenge, int carbonStorage, int biodiversity, int soilQuality)
    {
        locationText.text = location;
        challengeText.text = challenge;
        startingCarbonStorageValue.text = carbonStorage.ToString();
        startingBiodiversityValue.text = biodiversity.ToString();
        startingSoilQualityValue.text = soilQuality.ToString();
    }

    public void OnDisable()
    {
        buttonInteractable.WhenPointerEventRaised -= OnClick;
    }
}
