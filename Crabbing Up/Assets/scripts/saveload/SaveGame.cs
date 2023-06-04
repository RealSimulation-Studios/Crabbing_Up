using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class SaveGame : MonoBehaviour
{
    public string saveName = "savedGame";
    public string directoryName = "Saves";
    public SaveGameData saveGameData;

    public void SaveToFile()
    {
        saveName = PlayerPrefs.GetString("savegame");

        saveGameData.playerName = GameObject.Find("data").GetComponent<player_data>().Username;
        saveGameData.level = GameObject.Find("data").GetComponent<player_data>().level;
        saveGameData.health = GameObject.Find("data").GetComponent<player_data>().health;
        saveGameData.x = GameObject.Find("data").GetComponent<player_data>().x;
        saveGameData.y = GameObject.Find("data").GetComponent<player_data>().y;
        saveGameData.z = GameObject.Find("data").GetComponent<player_data>().z;

        // The formatter will convert our unity data type into a binary file
        BinaryFormatter formatter = new BinaryFormatter();

        // Choose the save location
        FileStream saveFile = File.Create(Application.persistentDataPath + "/Saves/" + saveName + ".crab");

        // Write our C# Unity game data type to a binary file
        formatter.Serialize(saveFile, saveGameData);

        saveFile.Close();
    }
}
