using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class LevelTracker : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private List<Transcribe> transcribes = new List<Transcribe>();
    [SerializeField] private int currentLevelIndex;

    [SerializeField] private Button confirmButton;

    [SerializeField] private GameObject goodEnding;
    [SerializeField] private GameObject badEnding;  

    [SerializeField] private bool wordIsCorrect;
    [SerializeField] private bool musicIsCorrect;
    [SerializeField] private bool pitchIsCorrect;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onSetWord += SetWordCorrectState;
        _eventManager.onSetMusic += SetMusicCorrectState;
        _eventManager.onSetPitch += SetPitchCorrectState;

        _eventManager.SetupLevelUI(transcribes[0]);
    }

    private void OnDisable()
    {
        _eventManager.onSetWord -= SetWordCorrectState;
        _eventManager.onSetMusic -= SetMusicCorrectState;
        _eventManager.onSetPitch -= SetPitchCorrectState;
    }

    private void Awake()
    {
        confirmButton.onClick.AddListener(()
            => CheckLevelCompletion());
    }

    private void CheckLevelCompletion()
    {
        if(wordIsCorrect && musicIsCorrect && pitchIsCorrect)
        {
            StartCoroutine(GoodEnding());
        }
        else
        {
            StartCoroutine(BadEnding());
        }
    }

    private void SetWordCorrectState(bool correct)
    {
        wordIsCorrect = correct;
    }

    private void SetMusicCorrectState(bool correct)
    {
        musicIsCorrect = correct;
    }

    private void SetPitchCorrectState(bool correct)
    {
        pitchIsCorrect = correct;
    }

    private IEnumerator GoodEnding()
    {
        goodEnding.SetActive(true);
        yield return new WaitForSeconds(2);
        goodEnding.SetActive(false);
        currentLevelIndex++;
        if(currentLevelIndex < transcribes.Count)
        {
            _eventManager.SetupLevelUI(transcribes[currentLevelIndex]);
        }
        else
        {
            Debug.Log("Game Over");
        }
    }

    private IEnumerator BadEnding()
    {
        badEnding.SetActive(true);
        yield return new WaitForSeconds(2);
        badEnding.SetActive(false);
        currentLevelIndex++;
        if (currentLevelIndex < transcribes.Count)
        {
            _eventManager.SetupLevelUI(transcribes[currentLevelIndex]);
        }
        else
        {
            Debug.Log("Game Over");
        }
    }
}
