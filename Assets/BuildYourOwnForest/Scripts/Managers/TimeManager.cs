using UnityEngine;
using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;

//Manages game and level time allowing for specific interruptions and timers. Wrote this to accommodate for the situation the game needs to be interrupted, as its intended use is a public space.
public class TimeManager : Manager {
    public static TimeManager Instance { get; private set; }

    public float GameTime => Time.time;
    public float LevelTime => levelTime;

    [ReadOnly][SerializeField] private float levelTime;
    [SerializeField] private bool isLevelTimeInterrupted;
    private float interruptionTime;
    [SerializeField] private List<Timer> timers = new();

    private struct Timer {
        public float StartTime;
        public float Duration;
        public bool UseLevelTime;
        public Action OnComplete;

        public Timer(float currentTime,float duration,bool useLevelTime,Action onComplete) {
            this.StartTime = currentTime;
            this.Duration = duration;
            this.UseLevelTime = useLevelTime;
            this.OnComplete = onComplete;
        }
    }


    void Awake() {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
    }

    void Update() {
        if (!isLevelTimeInterrupted) {
            levelTime = GameTime - interruptionTime;

            for (int i = timers.Count - 1; i >= 0; i--) {
                float currentTime = timers[i].UseLevelTime ? levelTime : GameTime;
                if (currentTime >= timers[i].StartTime + timers[i].Duration) {
                    timers[i].OnComplete();
                    timers.RemoveAt(i);
                }
            }
        }
        else {
            interruptionTime = GameTime - levelTime;
        }
    }

    /// <summary>
    /// Pauses the level time.
    /// </summary>
    public void PauseLevelTime() {
        isLevelTimeInterrupted = true;
    }

    /// <summary>
    /// Resumes the level time.
    /// </summary>
    public void ResumeLevelTime() {
        isLevelTimeInterrupted = false;
    }
    /// <summary>
    /// Start a timer.
    /// </summary>
    /// <param name="duration">In seconds</param>
    /// <param name="useLevelTime">If true uses LevelTime, otherwise uses GameTime</param>
    /// <param name="onComplete">Callback after duration</param>
    /// <returns></returns>
    public void StartTimer(float duration, bool useLevelTime, Action onComplete) {
        float currentTime = useLevelTime ? levelTime : GameTime;
        timers.Add(new Timer(currentTime, duration, useLevelTime, onComplete));
    }

    /// <summary>
    /// Removes all active timers from the TimeManager
    /// </summary>
    public void RemoveAllTimers()
    {
    }
}
