using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelTracker : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private List<Transcribe> transcribes = new List<Transcribe>();
    [SerializeField] private int currentLevelIndex;

    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
        _eventManager.SetupLevelUI(transcribes[0]);
    }
}
