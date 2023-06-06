using UnityEngine;

public class Discord_setMenu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Discord").GetComponent<Discord_Controller>().details = "Chilling in Main Menu";
        GameObject.Find("Discord").GetComponent<Discord_Controller>().state = "";
    }
}
