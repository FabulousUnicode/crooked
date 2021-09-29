using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinwheelHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal static void handleInteraction(Item item, Item lastUsed)
    {
        if(lastUsed.itemName == "Haarballen")
        {
            Inventory.instance.removeItem(lastUsed);
            Inventory.instance.addItem(ItemDatabaseInstance.getItemByName("string"));
            FindObjectOfType<Dialog>().showText("Der Faden ist noch ein wenig nass.");
        }
    }
}
