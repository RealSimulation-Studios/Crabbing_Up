using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_data : MonoBehaviour
{
    [Header("Player Data")]
    public string Username;
    public float level;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        GameObject.Find("save/load").GetComponent<GameLoader>().LoadFromFile();
    }

    public void Exit()
    {
        GameObject.Find("save/load").GetComponent<SaveGame>().SaveToFile();
        Application.Quit();
    }
}
