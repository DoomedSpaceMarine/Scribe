using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelTracker : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private List<Transcribe> transcribes = new List<Transcribe>();
    [SerializeField] private int currentLevelIndex;

    [SerializeField] private bool wordIsCorrect;
    [SerializeField] private bool musicIsCorrect;
    [SerializeField] private bool pitchIsCorrect;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onSetWord += SetWordCorrectState;

        _eventManager.SetupLevelUI(transcribes[0]);
    }

    private void OnDisable()
    {
        _eventManager.onSetWord -= SetWordCorrectState;
    }

    private void SetWordCorrectState(bool correct)
    {
        wordIsCorrect = correct;
    }
}
