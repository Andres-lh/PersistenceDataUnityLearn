using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MenuMainManager : MonoBehaviour
{
    public static MenuMainManager Instance;
    public string PlayerName { get; set; }
    public int BestScore { get; set; }
    public string BestScorePlayerName { get; set; }
    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadData();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    public void SavaData(int score)
    {
        SaveData data = new SaveData();
        data.playerName = PlayerName;
        data.score = score;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }


    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            BestScore = data.score;
            BestScorePlayerName= data.playerName;
        } else
        {
            BestScore = 0;
            BestScorePlayerName = "";
        }

    }
}



