using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsHandler : MonoBehaviour
{
    public GameObject bugs;

    public static bool aktiviert;

    internal void handleInteraction(Item item, Item lastUsed)
    {
        if(lastUsed.itemName == "Mottenkugeln")
        {
            Destroy(bugs);
            FindObjectOfType<Inventory>().removeItem(lastUsed);
            aktiviert = true;
        }
    }

    internal void handleInteractionNoItem()
    {
        throw new NotImplementedException();
    }

    public void Start()
    {
        if(aktiviert)
        {
            Destroy(bugs);
        }
    }
}
