using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player_data : MonoBehaviour
{   
    public GameObject player;

    [Header("Player Data")]
    public string Username;
    public float level;
    public float health;
    public float x;
    public float y;
    public float z;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        GameObject.Find("save/load").GetComponent<GameLoader>().LoadFromFile();

        Vector3 pos = new Vector3();
        pos.x = x;
        pos.y = y;
        pos.z = z;

        player.GetComponent<CharacterController>().enabled = false;
        player.GetComponent<Transform>().position = pos;
        player.GetComponent<CharacterController>().enabled = true;
    }

    public void Exit()
    {   
        Vector3 pos = new Vector3();
        pos = player.GetComponent<Transform>().position;
        x = pos.x;
        y = pos.y;
        z = pos.z;
        
        GameObject.Find("save/load").GetComponent<SaveGame>().SaveToFile();
        SceneManager.LoadScene(0);
    }
}
