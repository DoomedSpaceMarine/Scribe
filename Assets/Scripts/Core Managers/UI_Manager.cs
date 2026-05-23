using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public class UI_Manager : MonoBehaviour
{
    private EventManager _eventManager;

    //NPC & Background
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image npcImage;
    [SerializeField] private TextMeshProUGUI npcName;

    //Word
    [SerializeField] private List<AudioType> words = new List<AudioType>();
    [SerializeField] private Button[] wordButtons;

    //Music
    [SerializeField] private List<AudioType> musics= new List<AudioType>();
    [SerializeField] private Button[] musicButtons;

    //Pitch
    [SerializeField] private Button[] pitchButtons;

    //Current audioSources
    private AudioSource wordAudioSource;
    private AudioSource musicAudioSource;

    private Transcribe currentLevel;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onSetupLevelUI += SetupLevel;
        _eventManager.onSetActiveAudioSource += SetActiveAudioSource;
    }

    private void OnDisable()
    {
        _eventManager.onSetupLevelUI -= SetupLevel;
        _eventManager.onSetActiveAudioSource -= SetActiveAudioSource;
    }
    private void SetupLevel(Transcribe level)
    {
        words.Clear();
        musics.Clear();
        wordAudioSource = null;
        musicAudioSource = null;
        currentLevel= level;
        //Setup sprites and npc name
        backgroundImage.sprite = level.backgroundSprite;
        npcImage.sprite = level.npcSprite;
        npcName.text = level.npcName;

        //Setup words category
        words.Add(level.correctWords);
        for (int i = 0; i < level.incorrectWords.Length; i++)
        {
            words.Add(level.incorrectWords[i]);
        }
        ShuffleList(words);
        AssignWordButtons();

        //Setup music category
        musics.Add(level.correctMusic);
        for (int i = 0; i < level.incorrectMusic.Length; i++)
        {
            musics.Add(level.incorrectMusic[i]);    
        }
        ShuffleList(musics);
        AssignMusicButtons();

        //Setup pitch category
        AssignPitchButtons();

    }
    private void AssignWordButtons()
    {
        for(int i = 0; i < words.Count; i++)
        {
            wordButtons[i].onClick.RemoveAllListeners();
            if (words[i].correctAnswer)
            {
                wordButtons[i].onClick.AddListener(()
                    => WordCorrectButton());
                wordButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = words[i].description;
                wordButtons[i].GetComponent<AudioSource>().clip = words[i].audioClip;
            }
            else
            {
                wordButtons[i].onClick.AddListener(()
                    => WordIncorrectButton());
                wordButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = words[i].description;
                wordButtons[i].GetComponent<AudioSource>().clip = words[i].audioClip;
            }
        }
    }

    private void WordCorrectButton()
    {
        _eventManager.SetWordCorrectState(true);
        Debug.Log("Correct Word");
    }

    private void WordIncorrectButton()
    {
        _eventManager.SetWordCorrectState(false);
        Debug.Log("Incorrect Word");
    }

    private void AssignMusicButtons()
    {
        for (int i = 0; i < musics.Count; i++)
        {
            musicButtons[i].onClick.RemoveAllListeners();
            if (musics[i].correctAnswer)
            {
                musicButtons[i].onClick.AddListener(()
                    => MusicCorrectButton());
                musicButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = musics[i].description;
                musicButtons[i].GetComponent<AudioSource>().clip = musics[i].audioClip;
            }
            else
            {
                musicButtons[i].onClick.AddListener(()
                    => MusicIncorrectButton());
                musicButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = musics[i].description;
                musicButtons[i].GetComponent<AudioSource>().clip = musics[i].audioClip;
            }
        }
    }

    private void MusicCorrectButton()
    {
        _eventManager.SetMusicCorrectState(true);
        Debug.Log("Correct Music");
    }

    private void MusicIncorrectButton()
    {
        _eventManager.SetMusicCorrectState(false);
        Debug.Log("Incorrect Music");
    }

    private void AssignPitchButtons()
    {

        for (int i = 0; i < pitchButtons.Length; i++)
        {
            pitchButtons[i].onClick.RemoveAllListeners();
            if (i == 0 && currentLevel.correctPitch == AudioPitch.Low)
            {
                pitchButtons[i].onClick.AddListener(()
                    => PitchCorrectButton());
            }
            else if(i == 1 && currentLevel.correctPitch == AudioPitch.Medium)
            {
                pitchButtons[i].onClick.AddListener(()
                    => PitchCorrectButton());
            }
            else if (i == 2 && currentLevel.correctPitch == AudioPitch.High)
            {
                pitchButtons[i].onClick.AddListener(()
                    => PitchCorrectButton());
            }
            else
            {
                pitchButtons[i].onClick.AddListener(()
                    => PitchIncorrectButton());
            }
        }
        pitchButtons[0].onClick.AddListener(()
           => LowPitch());
        pitchButtons[1].onClick.AddListener(()
            => MediumPitch());
        pitchButtons[2].onClick.AddListener(()
            => HighPitch());
    }

    private void PitchCorrectButton()
    {
        _eventManager.SetPitchCorrectState(true);
        Debug.Log("Correct Pitch");
    }

    private void PitchIncorrectButton()
    {
        _eventManager.SetPitchCorrectState(false);
        Debug.Log("Incorrect Pitch");
    }

    private void LowPitch()
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.Stop();
            musicAudioSource.pitch = 0.5f;
            musicAudioSource.Play();
        }
        if(wordAudioSource != null)
        {
            wordAudioSource.Stop();
            wordAudioSource.pitch = 0.5f;
            wordAudioSource.Play();
        }
        Debug.Log("This runs");
    }

    private void MediumPitch()
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.Stop();
            musicAudioSource.pitch = 1;
            musicAudioSource.Play();
        }
        if (wordAudioSource != null)
        {
            wordAudioSource.Stop();
            wordAudioSource.pitch = 1;
            wordAudioSource.Play();
        }
    }

    private void HighPitch()
    {
        if (musicAudioSource != null)
        {
            musicAudioSource.Stop();
            musicAudioSource.pitch = 3f;
            musicAudioSource.Play();
        }
        if (wordAudioSource != null)
        {
            wordAudioSource.Stop();
            wordAudioSource.pitch = 3f;
            wordAudioSource.Play();
        }
    }

    private void SetActiveAudioSource(AudioSource audioSource, bool isWord)
    {
        if (isWord)
        {
            wordAudioSource = audioSource;
        }
        else
        {
            musicAudioSource= audioSource;
        }
    }

    public List<AudioType> ShuffleList(List<AudioType> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            AudioType temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }

}

[System.Serializable]
public class AudioType
{
    public string description;
    public AudioClip audioClip;
    public bool correctAnswer;
}
