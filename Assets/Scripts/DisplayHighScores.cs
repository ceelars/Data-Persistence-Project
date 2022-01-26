using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DisplayHighScores : MonoBehaviour
{
    public Text firstPlace, secondPlace, thirdPlace;

    void Awake()
    {
        UpdateScores();
    }

    void UpdateScores()
    {
        firstPlace.text = "1st: " + DataManager.firstPlaceName + " - " + DataManager.firstPlaceScore;
        secondPlace.text = "2nd: " + DataManager.secondPlaceName + " - " + DataManager.secondPlaceScore;
        thirdPlace.text = "3rd: " + DataManager.thirdPlaceName + " - " + DataManager.thirdPlaceScore;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
