using Oculus.Interaction;
using Oculus.Interaction.Demo;
using Oculus.Interaction.HandGrab;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.UIElements;
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

    [SerializeField]
    public enum Hand
    {
        LEFT,
        RIGHT
    }

    //[TitleGroup("References")]
    //[SerializeField] private  leftHand;
    //[SerializeField] private  rightHand;

    [TitleGroup("Settings")]
    [SerializeField] private bool isSimulating = false;

    [TitleGroup("Data")]
    [ReadOnly][SerializeField] private bool isLeftGrabbing;
    [ReadOnly][SerializeField] private bool isRightGrabbing;
    [ReadOnly][SerializeField] private Vector3 leftHandPosition;
    [ReadOnly][SerializeField] private Vector3 rightHandPosition;
    [ReadOnly][SerializeField] private List<InteractionZone> interactionZones;
    [ReadOnly][SerializeField] private List<Holdable> holdables;
    [ReadOnly][SerializeField] private GameObject simulationObject;
    [ReadOnly][SerializeField] private XRInput xrInput;

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

    /// <summary>
    /// Subscribes to grab input actions.
    /// </summary>
    private void OnEnable()
    {
        xrInput.Enable();

        xrInput.Grab.grabLeft.performed += OnGrabLeftPerformed;
        xrInput.Grab.grabLeft.canceled += OnGrabLeftCanceled;

        xrInput.Grab.grabRight.performed += OnGrabRightPerformed;
        xrInput.Grab.grabRight.canceled += OnGrabRightCanceled;
    }

    private void Start()
    {
        //create simulation object for testing purposes.
        if (isSimulating) 
        {
            simulationObject = SpawnTestCube();
        }

    }

    private void Update()
    {
        isLeftGrabbing = xrInput.Grab.grabLeft.IsPressed();
        isRightGrabbing = xrInput.Grab.grabRight.IsPressed();

        if (!isSimulating)
        {
            leftHandPosition = xrInput.PositionTracking.positionLeft.ReadValue<Vector3>();
            rightHandPosition = xrInput.PositionTracking.positionRight.ReadValue<Vector3>();
        }
        else
        {
            leftHandPosition = simulationObject.transform.position;
        }
        HighlightRoutine();
    }

    private void OnGrabPerformed(InputAction.CallbackContext context, Hand whichHand)
    {
        Vector3 _handPosition = whichHand == Hand.LEFT ? leftHandPosition : rightHandPosition;

        for (int i = 0; i < interactionZones.Count; i++)
        {
            InteractionZone zone = interactionZones[i];
            if (Vector3.Distance(_handPosition,zone.transform.position) < zone.InteractionDistance)
            {
                if (zone.AcceptedInteractionTypes.Contains(InteractionType.SELECT))
                {
                    zone.Interact?.Invoke(InteractionType.SELECT, whichHand);
                    return;
                }
            }
        }
    }

    private void OnGrabLeftPerformed(InputAction.CallbackContext context)
    {
        OnGrabPerformed(context, Hand.LEFT);
    }

    private void OnGrabLeftCanceled(InputAction.CallbackContext context)
    {
    }

    private void OnGrabRightPerformed(InputAction.CallbackContext context)
    {
        OnGrabPerformed(context, Hand.RIGHT);
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

    private void HighlightRoutine()
    {
        for (int i = 0; i < interactionZones.Count; i++)
        {
            InteractionZone zone = interactionZones[i];

            if (Vector3.Distance(leftHandPosition,zone.transform.position) < zone.HighlightDistance)
            {
                zone.UpdateHighlight(Vector3.Distance(leftHandPosition, zone.transform.position));
            }

             if (Vector3.Distance(rightHandPosition, zone.transform.position) < zone.HighlightDistance)
            {
                zone.UpdateHighlight(Vector3.Distance(rightHandPosition, zone.transform.position));
            }

        }
    }

    public void RegisterInteractionZone(InteractionZone zone)
    {
        interactionZones.Add(zone);
    }
    public void UnregisterInteractionZone(InteractionZone zone)
    {
        interactionZones.Remove(zone);
    }

    public void RegisterHoldable(Holdable holdable)
    {
        holdables.Add(holdable);
       // holdable.GrabInteractable.WhenInteractorRemoved.Action += 
    }
    public void UnregisterHoldable(Holdable holdable)
    {
        holdables.Remove(holdable);
    }

    private GameObject SpawnTestCube()
    {
        Vector3 _spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * 0.5f;
        Quaternion _spawnRotation = Quaternion.identity;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.SetParent(gameObject.transform);
        cube.transform.position = _spawnPosition;
        cube.transform.rotation = _spawnRotation;
        cube.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        return cube;
    }

    private GameObject SpawnTestCube(Vector3 position)
    {
        Vector3 _spawnPosition = position;
        Quaternion _spawnRotation = Quaternion.identity;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = _spawnPosition;
        cube.transform.rotation = _spawnRotation;
        cube.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        return cube;
    }

    [Button]
    public void SimulateGrab()
    {

    }
}
