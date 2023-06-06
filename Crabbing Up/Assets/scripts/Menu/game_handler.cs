using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Runtime.Serialization.Formatters.Binary;

public class game_handler : MonoBehaviour
{
    public string[] files;
    List<string> games = new List<string>();
    public string[] saved_games;
    public string ToLoad;

    public TMP_Dropdown savegame_dropdown;
    public TMP_InputField input;
    public Button ng_button;

    private SaveGameData saveGameData;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {   
        PlayerPrefs.SetInt("God", 0);
        ng_button.interactable = false;

        if(!Directory.Exists(Application.persistentDataPath + "/Saves"))
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/Saves");
        }

        files = Directory.GetFiles(Application.persistentDataPath + "/Saves/","*.crab", SearchOption.AllDirectories);

        for(int i = 0; i < files.Length; i++)
        {   
            string curr = files[i];
            string game = curr[(curr.IndexOf("Saves/") + 6)..(curr.Length - 5)];
            games.Add(game);
            Debug.Log("Converted");
        }

        saved_games = games.ToArray();

        savegame_dropdown.ClearOptions();

        savegame_dropdown.AddOptions(games);
    }

    public void Load()
    {   
        if(saved_games.Length < 1)
        {
            return;
        }

        ToLoad = saved_games[savegame_dropdown.value];
        if(ToLoad == "He's a God")
        {
            PlayerPrefs.SetInt("God", 1);
            print("Enabled God Mode");
        }
        PlayerPrefs.SetString("savegame", ToLoad);
        SceneManager.LoadScene(1);
    }

    public void update_text()
    {
        string text = input.text;
        bool error = true;

        if(text != "")
        {
            error = false;
        }

        for(int i = 0; i < saved_games.Length; i++)
        {
            if(games[i] == text)
            {
                error = true;
            }
        }

        if(error == true)
        {
            ng_button.interactable = false;
        }
        else
        {
            ng_button.interactable = true;
        }
    }

    public void newGame()
    {
        ToLoad = input.text;
        PlayerPrefs.SetString("savegame", ToLoad);

        saveGameData.playerName = "";
        saveGameData.level = 0.0f;
        saveGameData.health = 1.0f;
        saveGameData.x = 2202.0f;
        saveGameData.y = 60.0f;
        saveGameData.z = 1762.0f;

        // The formatter will convert our unity data type into a binary file
        BinaryFormatter formatter = new BinaryFormatter();

        // Choose the save location
        FileStream saveFile = File.Create(Application.persistentDataPath + "/Saves/" + ToLoad + ".crab");

        
        formatter.Serialize(saveFile, saveGameData);

        saveFile.Close();

        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
