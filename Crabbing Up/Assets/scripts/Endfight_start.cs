using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endfight_start : MonoBehaviour
{
    private bool state = true;
    public GameObject caris;
/// <summary>
/// OnTriggerEnter is called when the Collider other enters the trigger.
/// </summary>
/// <param name="other">The other Collider involved in this collision.</param>
private void OnTriggerEnter(Collider other)
{   
    if(state)
    {
        caris.SetActive(true);
        state = false;
    }
    
}
}
