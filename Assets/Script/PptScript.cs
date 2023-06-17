using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PptScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HidePPT()
    {
        gameObject.SetActive(false);
    }

    public void ShowPPT()
    {
        gameObject.SetActive(true);
    }
}
