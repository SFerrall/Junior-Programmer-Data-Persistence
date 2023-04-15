using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameInstance : MonoBehaviour
{
    public string playerName;
    public string highScorePlayer;
    public int highScore;

    public static GameInstance gameInstance;

    // Start is called before the first frame update
    void Start()
    {
        if (gameInstance != null)
        {
            Destroy(gameObject);
            return;
        }
        gameInstance = this;
        DontDestroyOnLoad(gameObject);

        LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [System.Serializable]
    class SaveData
    {
        public string highScorePlayer = "";
        public int highScore = 0;
    }

    public void SaveGame(int score)
    {
        SaveData data = new SaveData();
        data.highScore = score;
        data.highScorePlayer = playerName;

        string jsonData = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", jsonData);
    }

    public void LoadGame()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if(File.Exists(path))
        {
            string jsonData = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(jsonData);

            highScore = data.highScore;
            highScorePlayer = data.highScorePlayer;
        }
    }
}
