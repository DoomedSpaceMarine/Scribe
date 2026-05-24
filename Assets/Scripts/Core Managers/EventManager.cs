using UnityEngine;
using UnityEngine.UI;
using System;

public class EventManager : MonoBehaviour
{
   //Setup Level UI
   public event Action<Transcribe> onSetupLevelUI;
   public void SetupLevelUI(Transcribe level) => onSetupLevelUI?.Invoke(level);
    //Setup correct word state
    public event Action<bool> onSetWord;
    public void SetWordCorrectState(bool correct) => onSetWord?.Invoke(correct);
    //Setup correct music state
    public event Action<bool> onSetMusic;
    public void SetMusicCorrectState(bool correct) => onSetMusic?.Invoke(correct);
    //Setup correct pitch state
    public event Action<bool> onSetPitch;
    public void SetPitchCorrectState(bool correct) => onSetPitch?.Invoke(correct);
    //Set active audiosource
    public event Action<AudioSource, bool> onSetActiveAudioSource;
    public void SetActiveAudioSource(AudioSource audioSource, bool isWord) => onSetActiveAudioSource?.Invoke(audioSource, isWord);
    //Set button selected
    public event Action<ButtonType, Button> onSetButtonSelected;
    public void SetButtonSelected(ButtonType buttonType, Button button) => onSetButtonSelected?.Invoke(buttonType, button);
    //Mute all audio
    public event Action onMuteAllAudio;
    public void MuteAllAudio() => onMuteAllAudio?.Invoke();

}
