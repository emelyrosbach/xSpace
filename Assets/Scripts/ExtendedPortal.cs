using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendedPortal : BasicPortal
{
    public GameObject portalLiquid;
    public Material open;
    public Material closed;

    void Update()
    {
        if (gameManager.isCurrentPortalActive())
        {
            portalLiquid.GetComponent<Renderer>().material = open;
        }
        else
        {
            portalLiquid.GetComponent<Renderer>().material = closed;
        }
    }
}
