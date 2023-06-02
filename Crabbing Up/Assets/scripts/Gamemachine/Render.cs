using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Render : MonoBehaviour
{   
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;

    private IEnumerator coroutine;

    // Start is called before the first frame update
    void Start()
    {
        c1.SetActive(false);
        c2.SetActive(false);
        c3.SetActive(false);

        coroutine = Animation();
        StartCoroutine(coroutine);
        
    }

    // Update is called once per frame
    void Update()
    {}
    
    private IEnumerator Animation()
    {
        while (true)
        {
        c1.SetActive(true);
        c2.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        c2.SetActive(true);
        c1.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        c3.SetActive(true);
        c2.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        c2.SetActive(true);
        c3.SetActive(false);
        yield return new WaitForSeconds(0.2f);
        }
    }
}
