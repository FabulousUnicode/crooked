using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomatHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void handleInteraction(Item item, Item lastUsed)
    {
        if (lastUsed.itemName == "Münze") {
            Inventory.instance.removeItem(lastUsed);
            Inventory.instance.addItem(ItemDatabaseInstance.getItemByName("letter"));
            FindObjectOfType<Dialog>().showText("insert funny pun");
        }

    }
}
