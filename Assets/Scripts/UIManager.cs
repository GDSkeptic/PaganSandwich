using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameManager GM;
    public MainMenu MainMenu;
    public HighScores HighScores;

    public void HideMenu(bool _hide)
    {
        MainMenu.gameObject.SetActive(!_hide);
    }

    public void HideScores(bool _hide)
    {
        HighScores.gameObject.SetActive(!_hide);
    }

    void Update()
    {
        // input check
        if(Input.GetKey("escape"))
        {
            if (MainMenu.gameObject.activeInHierarchy)
                GM.ExitMainMenu();
            else
                GM.EnterMainMenu();
        }
    }
}
