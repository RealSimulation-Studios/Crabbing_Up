using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public class GameLoader : MonoBehaviour
{
    public string saveName = "savedGame";

    public void LoadFromFile()
    {   
        saveName = PlayerPrefs.GetString("savegame");
        
        // Converts binary file back into readable data for Unity game
        BinaryFormatter formatter = new BinaryFormatter();

        // Choosing the saved file to open
        FileStream saveFile = File.Open(Application.persistentDataPath + "/Saves/" + saveName + ".crab", FileMode.Open);

        // Convert the file data into SaveGameData format for use in game
        SaveGameData loadData = (SaveGameData) formatter.Deserialize(saveFile);

        GameObject.Find("data").GetComponent<player_data>().Username = loadData.playerName;
        GameObject.Find("data").GetComponent<player_data>().level = loadData.level;
        GameObject.Find("data").GetComponent<player_data>().health = loadData.health;
        

        saveFile.Close();
    }
}
