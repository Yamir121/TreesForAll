using Oculus.Interaction;
using Oculus.Interaction.Demo;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using static Oculus.Interaction.Context;

public class InteractionManager : Manager
{
    public static InteractionManager Instance { get; private set; }

    [SerializeField]
    public enum InteractionType
    {
        USE, //Uses the object in hand on interaction zone when object is released
        SELECT, // Selects the object attached to interaction zone when grab is triggered
        LONGSELECT, //Selects the object attached to interaction zone when grab is triggered for a specific duration
        NONE // No interactions are allowed
    }

    [TitleGroup("Data")]
    [ReadOnly][SerializeField] private XRInput xrInput;
    [ReadOnly][SerializeField] private bool isLeftGrabbing;
    [ReadOnly][SerializeField] private bool isRightGrabbing;
    [ReadOnly][SerializeField] private Vector3 leftHandPosition;
    [ReadOnly][SerializeField] private Vector3 rightHandPosition;
    [ReadOnly][SerializeField] private List<InteractionZone> interactionZones;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;

        xrInput = new XRInput();
    }

    private void OnEnable()
    {
        xrInput.Enable();

        xrInput.Grab.grabLeft.performed += OnGrabLeftPerformed;
        xrInput.Grab.grabLeft.canceled += OnGrabLeftCanceled;

        xrInput.Grab.grabRight.performed += OnGrabRightPerformed;
        xrInput.Grab.grabRight.canceled += OnGrabRightCanceled;
    }

    private void Update()
    {
        isLeftGrabbing = xrInput.Grab.grabLeft.IsPressed();
        isRightGrabbing = xrInput.Grab.grabRight.IsPressed();

        leftHandPosition = xrInput.PositionTracking.positionLeft.ReadValue<Vector3>();
        rightHandPosition = xrInput.PositionTracking.positionRight.ReadValue<Vector3>();

        CheckForInteractionZones();

    }
    private void OnGrabLeftPerformed(InputAction.CallbackContext context)
    {
        SpawnTestCube();
    }

    private void OnGrabLeftCanceled(InputAction.CallbackContext context)
    {
    }

    private void OnGrabRightPerformed(InputAction.CallbackContext context)
    {
    }

    private void OnGrabRightCanceled(InputAction.CallbackContext context)
    {
    }

    private void OnDisable()
    {
        xrInput.Grab.grabLeft.performed -= OnGrabLeftPerformed;
        xrInput.Grab.grabLeft.canceled -= OnGrabLeftCanceled;

        xrInput.Grab.grabRight.performed -= OnGrabRightPerformed;
        xrInput.Grab.grabRight.canceled -= OnGrabRightCanceled;

        xrInput.Disable();
    }

    private void CheckForInteractionZones()
    {
        for (int i = 0; i < interactionZones.Count; i++)
        {
            InteractionZone zone = interactionZones[i];
            // check for highlight
            float highlightDistanceSqr = zone.HighlightDistance * zone.HighlightDistance;
            if ((leftHandPosition - zone.transform.position).sqrMagnitude < highlightDistanceSqr || (rightHandPosition - zone.transform.position).sqrMagnitude < highlightDistanceSqr)
            {
                //highlight the zone
            }
            else
            {
                return;
            }
            //check for interaction
            float interactDistanceSqr = zone.InteractionDistance * zone.InteractionDistance;
            if ((leftHandPosition - zone.transform.position).sqrMagnitude < interactDistanceSqr || (rightHandPosition - zone.transform.position).sqrMagnitude < interactDistanceSqr) 
            {
                //interact with the zone
            }
            else
            {
                return;
            }
        }
    }

    private void SpawnTestCube()
    {
        Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;
        Quaternion spawnRotation = Quaternion.identity;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = spawnPosition;
        cube.transform.rotation = spawnRotation;
        cube.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
    }

    public void RegisterInteractionZone(InteractionZone zone)
    {
        interactionZones.Add(zone);
    }
    public void UnregisterInteractionZone(InteractionZone zone)
    {
        interactionZones.Remove(zone);
    }

}
