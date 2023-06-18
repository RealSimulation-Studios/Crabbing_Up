using UnityEngine;

public class Discord_set : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Discord").GetComponent<Discord_Controller>().details = "In Game";
        GameObject.Find("Discord").GetComponent<Discord_Controller>().state = PlayerPrefs.GetString("savegame");
    }
}
