using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsHandler : MonoBehaviour
{
    public GameObject broken_bars;

    public void handleInteraction(Item item, Item lastUsed)
    {
        if (lastUsed.itemName == "Säge")
        {
            FindObjectOfType<Inventory>().addItem(ItemDatabaseInstance.getItemByName("uranium_rods"));
            FindObjectOfType<Dialog>().showText("Ritsche Ratsche. Wow. Ein Leuchtstäbchen.");
            broken_bars.SetActive(true);

        }
        else
        {
            
        }
    }

    public void handleInteractionNoItem()
    {
        
    }
}
