using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
    public int index;
    public int starsPerLevel;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) { SaveData(); }
        if (Input.GetKeyDown(KeyCode.L)) { LoadData(); }
        if (Input.GetKeyDown(KeyCode.I)) { InitializePlayerData(); }
    }

    private void InitializePlayerData()
    {
        string path = Application.persistentDataPath + "/playerData.json";

        if (File.Exists(path)) { return; }

        PlayerData playerData = new PlayerData();
        playerData.coins = 0;
        playerData.energy = 5;
        playerData.stars = 0;
        playerData.arrayOfStarsPerLevel = new int[10];

        string contents = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, contents);
    }
    private void SaveData()
    {
        string path = Application.persistentDataPath + "/playerData.json";

        if (!File.Exists(path)) { return; }

        string contents = File.ReadAllText(path);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(contents);
        playerData.coins = 1;
        playerData.energy = 1;
        playerData.stars = 5;
        playerData.arrayOfStarsPerLevel[index] = starsPerLevel;

        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, json);
        Debug.Log($"Loading... coins {playerData.coins}, stars {playerData.stars}, energy {playerData.energy}");
    }

    private void LoadData()
    {
        string path = Application.persistentDataPath + "/playerData.json";

        if (!File.Exists(path)) { return; }

        string contents = File.ReadAllText(path);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(contents);
        Debug.Log($"Loading... coins {playerData.coins}, stars {playerData.stars}, energy {playerData.energy}");
    }
}