using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour
{
    #region Fields
    private static DataSaver m_instance;
    private const string m_jsonFileName = "/playerdata.json";
    #endregion

    #region Properties
    public static DataSaver instance => m_instance;
    #endregion


    #region Unity Methods
    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(this);
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) { SaveData(coins: 10, energy: 3, stars: 10, levelIndex: 0, starsPerLevel: 1); }
        if (Input.GetKeyDown(KeyCode.L)) { LoadData(); }
        if (Input.GetKeyDown(KeyCode.I)) { InitializePlayerData(); }
    }
#endif
    #endregion


    #region Public Methods
    public int GetCoins()
    {
        PlayerData playerData = LoadData();
        return playerData.coins;
    }
    public int GetEnergy()
    {
        PlayerData playerData = LoadData();
        return playerData.energy;
    }
    public int GetLevelStars()
    {
        PlayerData playerData = LoadData();
        return playerData.energy;
    }
    public int[] GetStarsForAllLevels()
    {
        PlayerData playerData = LoadData();
        return playerData.arrayOfStarsPerLevel;
    }
    #endregion


    #region Private Methods
    /// <summary>
    /// Initialize the PlayerData with default values
    /// </summary>
    private void InitializePlayerData()
    {
        string path = Application.persistentDataPath + "/playerdata.json";

        if (File.Exists(path)) { return; }

        // default data.
        PlayerData playerData = new PlayerData();
        playerData.coins = 0; // total amount of coins
        playerData.energy = 5; // total and max amount of energy
        playerData.stars = 0; // total amount of collected stars
        playerData.arrayOfStarsPerLevel = new int[10]; // based on the amount of levels

        string contents = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, contents);
        Debug.Log($"Data initialized and saved: {contents}");
    }

    /// <summary>
    /// Saves the PlayerData in a JSON file.
    /// </summary>
    /// <param name="coins">Amount of coins to add</param>
    /// <param name="energy">Amount of energy to assign</param>
    /// <param name="stars">Amount of stars to add</param>
    /// <param name="levelIndex">Current level index</param>
    /// <param name="starsPerLevel">Amount of stars of the current level</param>
    private void SaveData(int coins = -1, int energy = -1, int stars = -1, int levelIndex = -1, int starsPerLevel = -1)
    {
        string path = Application.persistentDataPath + m_jsonFileName;

        // check if no json file found, we initialize player data then save.
        if (!File.Exists(path)) { InitializePlayerData(); }

        string contents = File.ReadAllText(path);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(contents);
        if (coins >= 0) { playerData.coins += coins; } // add to the total coins.
        if (stars >= 0) { playerData.stars += stars; } // add to the total stars.
        if (energy >= 0) // add to the total energy.
        {
            playerData.energy = energy;
            playerData.energy = Mathf.Clamp(playerData.energy, 0, 5); // ..min 0 and max 5
        }
        if (levelIndex >= 0 && starsPerLevel >= 0) // assign new amount of stars to the level.
        {
            if (starsPerLevel > playerData.arrayOfStarsPerLevel[levelIndex]) // ..only when the new amount of stars is greater than the saved one
            {
                playerData.arrayOfStarsPerLevel[levelIndex] = starsPerLevel;
                playerData.arrayOfStarsPerLevel[levelIndex] = Mathf.Clamp(playerData.arrayOfStarsPerLevel[levelIndex], 0, 3); // ..min 0 and max 3
            }
        }

        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(path, json);
        Debug.Log($"Data saved: {json}");
    }

    /// <summary>
    /// It loads the PlayerData JSON.
    /// </summary>
    /// <returns>Loaded PlayerData</returns>
    private PlayerData LoadData()
    {
        string path = Application.persistentDataPath + m_jsonFileName;

        // check if no json file found, we initialize player data then load.
        if (!File.Exists(path)) { InitializePlayerData(); }

        string contents = File.ReadAllText(path);
        PlayerData playerData = JsonUtility.FromJson<PlayerData>(contents);
        Debug.Log($"Data loaded");
        return playerData;
    }
    #endregion
}