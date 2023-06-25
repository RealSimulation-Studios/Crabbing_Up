using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{

    

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        GameObject.Find("data").GetComponent<player_data>().health = 1.0f;
        GetComponent<AudioSource>().Play();
        Destroy(gameObject, 1.0f);
    }
}
