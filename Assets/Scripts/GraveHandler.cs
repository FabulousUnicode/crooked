using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveHandler : MonoBehaviour
{
 
    public void handleInteraction(Item item, Item lastUsed)
    {
        if (lastUsed.itemName == "Schaufel" && FindObjectOfType<Inventory>().searchItem("foot_bones") == false)
        {
            FindObjectOfType<Inventory>().addItem(ItemDatabaseInstance.getItemByName("foot_bones"));
        }
    }

    public void handleInteractionNoItem()
    {
        FindObjectOfType<Dialog>().showText("Wenn ich nur einen Riesenlöffel hätte.");
    }
}
