using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugsHandler : MonoBehaviour
{
    public GameObject bugs;
    internal void handleInteraction(Item item, Item lastUsed)
    {
        if(lastUsed.itemName == "Mottenkugeln")
        {
            bugs.SetActive(false);
            FindObjectOfType<Inventory>().removeItem(lastUsed);
        }
    }

    internal void handleInteractionNoItem()
    {
        throw new NotImplementedException();
    }
}
