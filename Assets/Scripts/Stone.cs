using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stone : MonoBehaviour
{
    public GameObject stoneInfo;
    // Start is called before the first frame update
    void Start()
    {
        stoneInfo.SetActive(false);
    }

    public void pickUp()
    {
        stoneInfo.SetActive(true);
    }

    public void drop()
    {
        stoneInfo.SetActive(false);
    }
}
