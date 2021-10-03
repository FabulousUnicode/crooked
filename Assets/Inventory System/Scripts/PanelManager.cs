using System;
using UnityEngine;



public class PanelManager : MonoBehaviour
{

    public GameObject inventoryPanel;

    public void Start()
    {
        inventoryPanel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            inventoryPanel.SetActive(true);

        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            inventoryPanel.SetActive(false);
        }
    }

    public bool getInventoryState()
    {
        return inventoryPanel.activeSelf;
    }

    public void closePanel()
    {
        inventoryPanel.SetActive(false);
    }
}
