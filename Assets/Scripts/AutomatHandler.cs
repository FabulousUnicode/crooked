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
        if (lastUsed.itemName == "Obolus")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(lastUsed);
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(ItemDatabaseInstance.getItemByName("letter"));
            FindObjectOfType<Dialog>().showText("Ein kleiner Preis für Erlösung.");
        }
        else
        {
            FindObjectOfType<Dialog>().showText("Das wird nicht funktionieren.");
        }

    }

    public static void handleInteractionNoItem(Item item)
    {
        FindObjectOfType<Dialog>().showText("Villeicht kann ich meine Hand durch den Schlitz stecken...     Neeee...");
    }
}