using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHandler : MonoBehaviour
{
    public static bool trigger;

    public void handleInteraction(Item item, Item lastUsed)
    {
        if(trigger && lastUsed.itemName == "Schaufel")
        {
            FindObjectOfType<Inventory>().addItem(ItemDatabaseInstance.getItemByName("treasure"));
        }
        else
        {
            Debug.Log("stuff");
        }
    }

    public void handleInteractionNoItem()
    {
        throw new NotImplementedException();
    }

    public static void setTrigger() {
        trigger = true;
    }
}
