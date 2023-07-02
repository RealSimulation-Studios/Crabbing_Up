using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speicherpunkt : MonoBehaviour
{
    public GameObject activationGroup;
    public GameObject deactivationGroup;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        int _god = PlayerPrefs.GetInt("God");

        if(_god == 1)
        {
            this.GetComponent<MeshRenderer>().enabled = true;
        }
        else
        {
            this.GetComponent<MeshRenderer>().enabled = false;
        }


        
    }



    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    private void OnTriggerEnter(Collider other)
    {   
                if(other.tag == "Player")
        {
        deactivationGroup.SetActive(false);
        activationGroup.SetActive(true);
        
        float h = GameObject.Find("data").GetComponent<player_data>().health;
        GameObject.Find("data").GetComponent<player_data>().health = 1.0f;

        GameObject.Find("data").GetComponent<player_data>().save();
        
        GameObject.Find("data").GetComponent<player_data>().health = h;
        print("done");
        }
    }


}
