using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_TitleScreen : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button exitButton;

    private void Awake()
    {
        playButton.onClick.AddListener(()
            => PlayButton());
        exitButton.onClick.AddListener(() 
            => ExitButton());
    }

    private void PlayButton()
    {
        SceneManager.LoadScene("Level");
    }

    private void ExitButton()
    {
        Application.Quit();
    }
}
