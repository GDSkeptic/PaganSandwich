using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public UIManager UI;

    void Start()
    {
        if (ScoreUpdate.ShowMenuOnStartup)
            EnterMainMenu();
    }

    public void StartNewGame()
    {
        ExitMainMenu();
        ScoreUpdate.ShowMenuOnStartup = false;
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EnterMainMenu()
    {
        UI.HideMenu(false);
        Time.timeScale = 0;
    }

    public void ExitMainMenu()
    {
        UI.HideMenu(true);
        Time.timeScale = 1;
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
