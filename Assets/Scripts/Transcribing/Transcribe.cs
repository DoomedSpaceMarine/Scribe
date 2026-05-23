using UnityEngine;

[CreateAssetMenu(fileName = "Transcribe", menuName = "Scriptable Objects/Transcribe")]
public class Transcribe : ScriptableObject
{
    [Header("Character/Location")]
    public string npcName;
    public Sprite npcSprite;
    public Sprite backgroundSprite;

    [Header("Ritual")]
    public AudioClip correctMusic;
    public AudioClip[] incorrectMusic;
    public AudioPitch correctPitch;
    public AudioClip correctWords;
    public AudioClip[] incorrectWords;
}

public enum AudioPitch
{
    Low,
    Medium,
    High,
}
