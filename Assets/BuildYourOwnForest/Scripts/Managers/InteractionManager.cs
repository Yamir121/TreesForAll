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

    public HandGrabInteractor LeftHandInteractor => leftHandInteractor;
    public HandGrabInteractor RightHandInteractor => rightHandInteractor;

    [TitleGroup("References")]
    [SerializeField] private HandGrabInteractor leftHandInteractor;
    [SerializeField] private HandGrabInteractor rightHandInteractor;
    [SerializeField] private Transform leftHandTransform;
    [SerializeField] private Transform rightHandTransform;

    [TitleGroup("Settings")]
    [SerializeField] private bool interactionsActive;
    //[SerializeField] private bool isSimulating = false;

    [TitleGroup("Data")]
    [ReadOnly][SerializeField] private bool leftHandIsGrabbing;
    [ReadOnly][SerializeField] private bool rightHandIsGrabbing;
    [ReadOnly][SerializeField] private List<InteractionZone> interactionZones;
    [ReadOnly][SerializeField] private List<Holdable> CurrentlyHeldObjects;
    [ReadOnly][SerializeField] private GameObject simulationObject;

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
        if (interactionsActive) {
            if (leftHandInteractor != null && leftHandInteractor.State != InteractorState.Disabled)
            {
                if (!leftHandIsGrabbing && leftHandInteractor.IsGrabbing)
                {
                    OnGrabPerformed(Hand.LEFT);
                }
                else
                {
                    //OnGrabOngoing();
                }
                leftHandIsGrabbing = leftHandInteractor.IsGrabbing;
            }
            if (rightHandInteractor != null && rightHandInteractor.State != InteractorState.Disabled)
            {
                if (!rightHandIsGrabbing && rightHandInteractor.IsGrabbing)
                {
                    OnGrabPerformed(Hand.RIGHT);
                }
                else
                {
                    //OnGrabOngoing();
                }
                rightHandIsGrabbing = rightHandInteractor.IsGrabbing;
            }

            HighlightRoutine();
        }
    }

    private void OnGrabPerformed(Hand whichHand)
    {

        Vector3 _handPosition = whichHand == Hand.LEFT ? leftHandTransform.position : rightHandTransform.position;
        SpawnTestCube(_handPosition);
        SpawnTestCube(rightHandInteractor.transform.position);

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

    private void OnObjectReleased(HandGrabInteractor interactor)
    {
        for (int i = 0; i < interactionZones.Count; i++)
        {
            InteractionZone zone = interactionZones[i];

            if (Vector3.Distance(interactor.gameObject.transform.position, zone.transform.position) < zone.InteractionDistance)
            {
                var holdable = interactor.SelectedInteractable.GetComponent<Holdable>();
                Hand _hand = interactor == leftHandInteractor ? Hand.LEFT : Hand.RIGHT; 
                TimeManager.Instance.StartTimer(1, false, () => holdable.Despawn());
                zone.Interact?.Invoke(InteractionType.USE, _hand);
            }
        }
    }

    private void HighlightRoutine()
    {
        for (int i = 0; i < interactionZones.Count; i++)
        {
            InteractionZone zone = interactionZones[i];

            if (Vector3.Distance(leftHandTransform.position,zone.transform.position) < zone.HighlightDistance)
            {
                zone.UpdateHighlight(Vector3.Distance(leftHandTransform.position, zone.transform.position), true);
            }

             if (Vector3.Distance(rightHandTransform.position, zone.transform.position) < zone.HighlightDistance)
            {
                zone.UpdateHighlight(Vector3.Distance(rightHandTransform.position, zone.transform.position), true);
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
        CurrentlyHeldObjects.Add(holdable);
        holdable.GrabInteractable.WhenInteractorRemoved.Action += OnObjectReleased;
    }
    public void UnregisterHoldable(Holdable holdable)
    {
        CurrentlyHeldObjects.Remove(holdable);
    }

    public GameObject SpawnTestCube()
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

    public GameObject SpawnTestCube(Vector3 position)
    {
        Vector3 _spawnPosition = position;
        Quaternion _spawnRotation = Quaternion.identity;

        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
        cube.transform.position = _spawnPosition;
        cube.transform.rotation = _spawnRotation;
        cube.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
        return cube;
    }
}
