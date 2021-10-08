using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirefliesHandler : MonoBehaviour
{
    public void handleInteraction(Item item, Item lastUsed)
    {
        Debug.Log(lastUsed.itemName);
        if(lastUsed.itemName == "Glass mit Löchern")
        {
            FindObjectOfType<Inventory>().removeItem(lastUsed);
            FindObjectOfType<Inventory>().addItem(ItemDatabaseInstance.getItemByName("jar_with_fireflies"));
            FindObjectOfType<Dialog>().showText("Ab ins Glas!");
        }
        else
        {

        }
    }

    public void handleInteractionNoItem()
    {
        throw new NotImplementedException();
    }
}
