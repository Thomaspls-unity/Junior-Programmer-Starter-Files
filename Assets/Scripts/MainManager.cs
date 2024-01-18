using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public Color teamColor;

    private void Awake()
    {
        SetSingleton();

        LoadColor();
    }

    public void SaveColor()
    {
        SaveData saveData = new SaveData();
        saveData.teamColor = teamColor;

        string jsonToSave = JsonUtility.ToJson(saveData);
        Debug.Log(jsonToSave);

        File.WriteAllText(Application.persistentDataPath + "/saveFile.json", jsonToSave);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/saveFile.json";

        if (File.Exists(path))
        {
            string jsonToLoad = File.ReadAllText(path);

            SaveData loadData = JsonUtility.FromJson<SaveData>(jsonToLoad);

            teamColor = loadData.teamColor;
        }
    }

    private void SetSingleton()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

[System.Serializable]
class SaveData
{
    public Color teamColor;
}
