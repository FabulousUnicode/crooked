using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarsHandler : MonoBehaviour
{
    public GameObject broken_bars;
    public static bool triggered;


    public void Start()
    {
        if (triggered)
        {
            broken_bars.SetActive(true);
            gameObject.SetActive(false);
        }
    }


    public void handleInteraction(Item item, Item lastUsed)
    {
        if (lastUsed.itemName == "S�ge")
        {
            FindObjectOfType<Inventory>().addItem(ItemDatabaseInstance.getItemByName("uranium_rods"));
            FindObjectOfType<Dialog>().showText("Ritsche Ratsche. Wow. Ein Leuchtst�bchen.");
            broken_bars.SetActive(true);
            gameObject.SetActive(false);
            triggered = true;

        }
        else
        {
            
        }
    }

    public void handleInteractionNoItem()
    {
        
    }
}
