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

    void updateHighscore(int score)
    {
        PlayerPrefs.SetInt("Score", score);
    }
}
