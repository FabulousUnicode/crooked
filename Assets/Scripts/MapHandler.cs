using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapHandler : MonoBehaviour
{

    public GameObject map;
    public GameObject closingButton;


    public void handleInteraction()
    {
        map.SetActive(true);
        TreasureHandler.setTrigger();        
        FindObjectOfType<PanelManager>().closePanel();
    }

    public void closeMap()
    {
        map.SetActive(false);
    }
}
