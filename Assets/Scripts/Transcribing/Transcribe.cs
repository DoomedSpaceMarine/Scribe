using UnityEngine;

[CreateAssetMenu(fileName = "Transcribe", menuName = "Scriptable Objects/Transcribe")]
public class Transcribe : ScriptableObject
{
    [Header("Character/Location")]
    public string npcName;
    public Sprite npcSprite;
    public Sprite backgroundSprite;

    [Header("Ritual")]
    public AudioType correctMusic;
    public AudioType[] incorrectMusic;
    public AudioPitch correctPitch;
    public AudioType correctWords;
    public AudioType[] incorrectWords;
}

public enum AudioPitch
{
    Low,
    Medium,
    High,
}
