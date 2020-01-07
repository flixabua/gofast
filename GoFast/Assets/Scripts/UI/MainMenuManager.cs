using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public UnityEngine.UI.Button button1, button2, button3;

    private void Start()
    {
        if(PlayerPrefs.GetInt("Score", 0) == 0 && button2 != null && button3 != null)
        {
            button2.interactable = false;
            button3.interactable = false;
        }
    }
    public void LoadLevelByIndex(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevelByName(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void CloseGame()
    {
        Application.Quit();
    }
}
