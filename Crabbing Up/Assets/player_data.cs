using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_data : MonoBehaviour
{
    [Header("Player Data")]
    public string Username;
    public float level;
    public float health;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        GameObject.Find("save/load").GetComponent<GameLoader>().LoadFromFile();
    }

    public void Exit()
    {
        GameObject.Find("save/load").GetComponent<SaveGame>().SaveToFile();
        SceneManager.LoadScene(0);
    }
}
