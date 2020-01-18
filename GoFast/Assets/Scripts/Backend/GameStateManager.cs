/*
 * written by Felix Völk
 * 
 * Used to save highscores and get them
 * 
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    int highscore;
    void Start()
    {
        highscore = PlayerPrefs.GetInt("Score", 0);
    }

    public static void updateHighscore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
        Debug.Log(PlayerPrefs.GetInt("Score"));
    }
}
