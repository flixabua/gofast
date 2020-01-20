/*
 * written by Felix Völk
 * 
 * Change level with buttons and, close game 
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public UnityEngine.UI.Button button1, button2, button3;
    public static Text playerStats;

    private void Start()
    {
        playerStats = GameObject.Find("Highscore").GetComponent<Text>();
        if (PlayerPrefs.GetInt("Score", 0) == 0 && button2 != null && button3 != null)
        {
            button2.interactable = false;
            button3.interactable = false;
        }
        UpdateStats();
    }
    public void LoadLevelByIndex(int levelIndex)
    {
        UpdateStats();
        SceneManager.LoadScene(levelIndex);
    }

    public void LoadLevelByName(string levelName)
    {
        UpdateStats();
        SceneManager.LoadScene(levelName);
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void UpdateStats()
    {
        playerStats.text = "Highscore:\n" + PlayerPrefs.GetFloat("Score").ToString();
    }
}
