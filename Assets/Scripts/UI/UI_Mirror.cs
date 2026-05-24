using UnityEngine;
using UnityEngine.UI;

public class UI_Mirror : MonoBehaviour
{
    [SerializeField] private GameObject lovecraftianHorror;
    [SerializeField] private GameObject bitcoin;
    [SerializeField] private Button mirrorButton;

    [SerializeField] private AudioSource menuSong;
    [SerializeField] private AudioSource horrorMusic;

    private void Awake()
    {
        mirrorButton.onClick.AddListener(()
            => RevealHorror());
    }

    private void RevealHorror()
    {
        menuSong.gameObject.SetActive(false);
        bitcoin.gameObject.SetActive(true);
        horrorMusic.Play();
        mirrorButton.interactable = false;
        lovecraftianHorror.SetActive(true);
    }

}
