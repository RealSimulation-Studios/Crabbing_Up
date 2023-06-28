using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GamemachineCollider : MonoBehaviour
{
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {   
                if(other.tag == "Player")
        {
        Vector3 pos = new Vector3(2254.0f, 80.0f, 2452.0f);
        GameObject.Find("Player").GetComponent<Transform>().position = pos;
        
        GameObject.Find("data").GetComponent<player_data>().save();
        SceneManager.LoadScene(4);
        }
    }
}
