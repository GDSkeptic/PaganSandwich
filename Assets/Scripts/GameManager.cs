using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public UIManager UI;

    public void StartNewGame()
    {
        SceneManager.LoadScene("Main");
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void EnterMainMenu()
    {
        UI.HideMenu(false);
    }

    public void ExitMainMenu()
    {
        UI.HideMenu(true);
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
