using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInfo : MonoBehaviour
{
    public GameObject StartCanvas;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCanvas.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        Debug.Log("tutorial");
        StartCanvas.SetActive(false);
    }
}
