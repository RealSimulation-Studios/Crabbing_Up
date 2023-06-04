using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key_handler : MonoBehaviour
{   
    public GameObject Menu;
    public GameObject Movement;

    private bool inMenu = false;

    // Start is called before the first frame update
    void Start()
    {
        Menu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && inMenu == true)
        {   
            Menu.SetActive(false);
            Movement.SetActive(true);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            inMenu = false;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.Escape) && inMenu == false)
            {   
                Menu.SetActive(true);
                Movement.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                inMenu = true;
            }
        }
    }
}
