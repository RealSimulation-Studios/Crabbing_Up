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
    }
}
