using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectile : MonoBehaviour
{   
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnCollisionEnter is called when this collider/rigidbody has begun
    /// touching another rigidbody/collider.
    /// </summary>
    private void OnCollisionEnter(Collision other)
    {   
        GetComponent<AudioSource>().Play();
        
        Destroy(GameObject.Find("projectile(Clone)"), 10);
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    private void OnTriggerEnter(Collider other)
    {
        print(other.tag);
        if(other.tag == "Player")
        {
            GameObject.Find("data").GetComponent<player_data>().health = GameObject.Find("data").GetComponent<player_data>().health - 0.1f;
        }
    }
}
