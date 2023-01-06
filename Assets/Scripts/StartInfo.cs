using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartInfo : MonoBehaviour
{
    public GameObject StartCanvas;
    public GameObject NextButton;
    public GameObject Instruction1;
    public GameObject Instruction2;

    // Start is called before the first frame update
    void Start()
    {
        StartCanvas.SetActive(true);
        Instruction1.SetActive(true);
        Instruction2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCloseClick()
    {
        StartCanvas.SetActive(false);
    }

    public void OnNextClick()
    {
        Instruction1.SetActive(false);
        Instruction2.SetActive(true);
        NextButton.SetActive(false);
    }
}
