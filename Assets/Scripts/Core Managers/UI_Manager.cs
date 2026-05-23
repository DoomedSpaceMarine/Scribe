using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;
using System.Linq;

public class UI_Manager : MonoBehaviour
{
    //NPC & Background
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image npcImage;
    [SerializeField] private TextMeshProUGUI npcName;

    //Word
    [SerializeField] private List<AudioClip> words = new List<AudioClip>();
    [SerializeField] private Button wordOption1;
    [SerializeField] private Button wordOption2;
    [SerializeField] private Button wordOption3;

    //Pitch
    [SerializeField] private Button pitchLow;
    [SerializeField] private Button pitchMedium;
    [SerializeField] private Button pitchHigh;
    private void SetupLevel(Transcribe level)
    {
        //Setup sprites and npc name
        backgroundImage.sprite = level.backgroundSprite;
        npcImage.sprite = level.npcSprite;
        npcName.text = level.npcName;

        //Setup words category
        words.Add(level.correctWords);
        for(int i = 0; i < level.incorrectWords.Length; i++)
        {
            words.Add(level.incorrectWords[i]);
        }
        ShuffleList(words);
    }

    public List<AudioClip> ShuffleList(List<AudioClip> list)
    {
        System.Random random = new System.Random();
        return list.OrderBy(x => random.Next()).ToList();
    }
}
