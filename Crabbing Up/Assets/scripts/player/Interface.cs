using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{   
   float health;

    public Image healtBarImage;

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        health = GameObject.Find("data").GetComponent<player_data>().health;
        healtBarImage.fillAmount = health;

        if(health <= 0.0f)
        {
            SceneManager.LoadScene(1);
        }
    }
}
