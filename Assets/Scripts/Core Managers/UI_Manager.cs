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
    [SerializeField] private List<WordType> words = new List<WordType>();
    [SerializeField] private Button[] wordButtons;

    //Music
    
    

    //Pitch
    [SerializeField] private Button pitchLow;
    [SerializeField] private Button pitchMedium;
    [SerializeField] private Button pitchHigh;

    private void OnEnable()
    {
        _eventManager = FindFirstObjectByType<EventManager>();

        _eventManager.onSetupLevelUI += SetupLevel;
    }

    private void OnDisable()
    {
        _eventManager.onSetupLevelUI += SetupLevel;
    }
    private void SetupLevel(Transcribe level)
    {
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
                wordButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = words[i].word;
                wordButtons[i].GetComponent<AudioSource>().clip = words[i].wordClip;
            }
            else
            {
                wordButtons[i].onClick.AddListener(()
                    => WordIncorrectButton());
                wordButtons[i].GetComponentInChildren<TextMeshProUGUI>().text = words[i].word;
                wordButtons[i].GetComponent<AudioSource>().clip = words[i].wordClip;
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

    public List<WordType> ShuffleList(List<WordType> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = UnityEngine.Random.Range(0, i + 1);
            WordType temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
        return list;
    }

}

[System.Serializable]
public class WordType
{
    public string word;
    public AudioClip wordClip;
    public bool correctAnswer;
}
