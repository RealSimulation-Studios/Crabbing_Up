using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public string saveDirectory = "Saves";
    public string saveName = "savedGame";
    public GameObject data;

    public void LoadFromFile()
    {
        // Converts binary file back into readable data for Unity game
        BinaryFormatter formatter = new BinaryFormatter();

        // Choosing the saved file to open
        FileStream saveFile = File.Open(Application.persistentDataPath + "/" + saveName + ".crab", FileMode.Open);

        // Convert the file data into SaveGameData format for use in game
        SaveGameData loadData = (SaveGameData) formatter.Deserialize(saveFile);

        GameObject.Find("data").GetComponent<player_data>().Username = loadData.playerName;
        GameObject.Find("data").GetComponent<player_data>().level = loadData.level;
        

        saveFile.Close();
    }
}
