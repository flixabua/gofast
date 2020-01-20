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
    float highscore;
    void Start()
    {
        highscore = PlayerPrefs.GetFloat("Score", 0f);
    }

    public static void updateHighscore(float score)
    {
        PlayerPrefs.SetFloat("Score", score);
        Debug.Log(PlayerPrefs.GetInt("Score"));
    }

    public static float getHighscore() {
        return PlayerPrefs.GetFloat("Score");
    }
}
