using UnityEngine;

public class Skin : MonoBehaviour
{
    public GameObject W0;
    public GameObject W1;
    public GameObject W2;
    public GameObject W3;

    public GameObject Caris;

    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
        W0.SetActive(true);
        W1.SetActive(false);
        W2.SetActive(false);
        W3.SetActive(false);
    }

    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    private void Update()
    {
        int cWave = Caris.GetComponent<Wave>().currWave;
        
        if(cWave == 1)
        {
            W1.SetActive(true);
            W0.SetActive(false);
            W2.SetActive(false);
            W3.SetActive(false);
        }

        if(cWave == 2)
        {
            W2.SetActive(true);
            W0.SetActive(false);
            W1.SetActive(false);
            W3.SetActive(false);
        }

        if(cWave == 3)
        {
            W3.SetActive(true);
            W0.SetActive(false);
            W2.SetActive(false);
            W1.SetActive(false);
        }
        
    }
}

