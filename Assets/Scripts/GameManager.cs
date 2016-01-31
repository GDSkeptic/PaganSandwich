using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public UIManager UI;

    AudioSource[] Music;

    int CurrentMusicIndex = 1;

    void SwitchClip(int _index)
    {
        if (_index >= 0 && _index < Music.Length)
        {
            Music[CurrentMusicIndex].volume = 0;
            CurrentMusicIndex = _index;
            Music[CurrentMusicIndex].volume = 1;
        }
    }

    public void AdvanceMusic()
    {
        SwitchClip(CurrentMusicIndex + 1);
    }

    void Start()
    {
        Music = GetComponents<AudioSource>();
        if (ScoreUpdate.ShowMenuOnStartup)
            EnterMainMenu();
        else
        {
            CurrentMusicIndex = 1;
            Music[0].volume = 0;
            Music[CurrentMusicIndex].volume = 1;
        }
    }

    public void StartNewGame()
    {
        ExitMainMenu();
        ScoreUpdate.ShowMenuOnStartup = false;
        SceneManager.LoadScene("Main");
        Music[0].volume = 0;
        SwitchClip(1);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EnterMainMenu()
    {
        UI.HideMenu(false);
        Time.timeScale = 0;
        Music[CurrentMusicIndex].volume = 0;
        Music[0].volume = 1;
    }

    public void ExitMainMenu()
    {
        UI.HideMenu(true);
        Time.timeScale = 1;
        Music[0].volume = 0;
        Music[CurrentMusicIndex].volume = 1;
    }

    public void EnterHighScores()
    {
        UI.HideMenu(true);
        UI.HideScores(false);
    }

    public void ExitHighScores()
    {
        UI.HideScores(true);
        UI.HideMenu(false);
    }
}
