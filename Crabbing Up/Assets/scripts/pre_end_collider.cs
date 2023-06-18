using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pre_end_collider : MonoBehaviour
{
    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {
        SceneManager.LoadScene(3);   
    }
}
