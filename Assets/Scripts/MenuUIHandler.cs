using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    public Text bestScore, playerName;

    void Awake()
    {
        UpdateBestScore();
    }

    // Update is called once per frame
    public void StartGame()
    {
        if (playerName.text != null)
        {
            DataManager.playerName = playerName.text;
            SceneManager.LoadScene(1);
        }
        else
            GameObject.Find("NameWarning").SetActive(true);
    }
    public void ViewHighScores()
    {
        SceneManager.LoadScene(2);
    }
    public void ExitGame()
    {
        DataManager.SaveHighScores();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
    public void UpdateBestScore()
    {
        bestScore.text = "Best Score: " + DataManager.firstPlaceName + " " + DataManager.firstPlaceScore;
    }
}
