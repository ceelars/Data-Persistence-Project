using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    public MenuUIHandler menuUIHandler;

    public static DataManager instance;
    public static string firstPlaceName, secondPlaceName, thirdPlaceName, playerName;
    public static int firstPlaceScore, secondPlaceScore, thirdPlaceScore, playerScore;

    private void Start()
    {
        LoadHighScores();
        menuUIHandler.UpdateBestScore();
    }
    private void Awake()
    {
        Singleton();
    }

    private void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    [System.Serializable]
    class SaveData
    {
        public string firstPlaceName, secondPlaceName, thirdPlaceName;
        public int firstPlaceScore, secondPlaceScore, thirdPlaceScore;
    }
    public static void SaveHighScores()
    {
        SaveData data = new SaveData();
        data.firstPlaceName = firstPlaceName;
        data.firstPlaceScore = firstPlaceScore;
        data.secondPlaceName = secondPlaceName;
        data.secondPlaceScore = secondPlaceScore;
        data.thirdPlaceName = thirdPlaceName;
        data.thirdPlaceScore = thirdPlaceScore;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }
    void LoadHighScores()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            firstPlaceName = data.firstPlaceName;
            firstPlaceScore = data.firstPlaceScore;
            secondPlaceName = data.secondPlaceName;
            secondPlaceScore = data.secondPlaceScore;
            thirdPlaceName = data.thirdPlaceName;
            thirdPlaceScore = data.thirdPlaceScore;
        }
    }
}
