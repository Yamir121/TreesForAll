using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

//Core manager, responsible for starting and ending the game, level instances and UI instances.
public class GameManager : Manager
{
    public static GameManager Instance { get; private set; }
    public float LevelLength => levelLength;
    public Vector2 GroundSize => groundSize;

    [TitleGroup("Global Game Settings")]
    /// <summary>
    /// Duration of a level in Seconds
    /// </summary>
    [SerializeField] private float levelLength;
    /// <summary>
    /// Size of the ground grid in meters.
    /// </summary>
    [SerializeField] private Vector2 groundSize = new Vector2(5,5);
    /// <summary>
    /// List of available challenges to play.
    /// </summary>
    [SerializeField] private List<Challenge> challengePool;
    /// <summary>
    /// List of available locations to play in.
    /// </summary>
    [SerializeField] private List<Location> locationsPool;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        StartGame();
    }

    [Button]
    private void StartGame()
    {
        Debug.Log("Game Has Started!");
        StartCoroutine(GameSequence());
    }

    private IEnumerator GameSequence()
    {
        //pick random level + challenge
        var chosenLocation = GetRandomLocationFromPool();
        var chosenChallenge = GetRandomChallengeFromPool();
        //showUI with challenge and level
        StartUIWindow startUIWindow = UIManager.Instance.ShowStartUIWindow(chosenLocation, chosenChallenge);
        
        yield return new WaitUntil(() => startUIWindow.ButtonPressed);
        //Start level instance
        UIManager.Instance.HideStartUIWindow();
        LevelManager.Instance.StartLevelInstance(chosenLocation, chosenChallenge);
    }

    [Button]
    private void InterruptLevel()
    {

    }

    [Button]
    private void ResumeLevel()
    {

    }

    [Button]
    private void StopLevelPrematurely()
    {
        StartCleanupSequence();
    }

    private void StartCleanupSequence()
    {
        //LevelManager.Instance.Cleanup();
    }

    private Challenge GetRandomChallengeFromPool()
    {
        return challengePool[Random.Range(0, challengePool.Count)];
    }

    private Location GetRandomLocationFromPool()
    {
        return locationsPool[Random.Range(0, locationsPool.Count)];
    }

}
