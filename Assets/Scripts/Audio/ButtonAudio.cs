using UnityEngine;

public class ButtonAudio : MonoBehaviour
{
    private EventManager _eventManager;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private bool isWordButton;

    private void Start()
    {
        _eventManager = FindFirstObjectByType<EventManager>();
    }

    public void ButtonClicked()
    {
        _eventManager.MuteAllAudio();
        _eventManager.SetActiveAudioSource(audioSource, isWordButton);
    }
}
