using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BowlHandler : MonoBehaviour
{
    
    public GameObject bird;
    public GameObject bowl;
    public GameObject hairball;

    public static bool trigger = false;

    void Start()
    {
        if (!trigger)
        {
            bowl.SetActive(true);
            hairball.SetActive(false);
        }
        else
        {
            hairball.SetActive(true);
            bowl.SetActive(false);
        }
    }

    public void handleInteraction(Item item, Item lastUsed)
    {
        if (lastUsed.itemName == "Antiker Vogel")
        {
            FindObjectOfType<Inventory>().removeItem(lastUsed);
            bird.SetActive(true);
            //bowl.SetActive(false);
            trigger = true;

        }
        else
        {
            
        }
    }

    internal void handleInteractionNoItem()
    {
        FindObjectOfType<Dialog>().showText("Ich will garnicht wissen wann die zuletzt gespült wurde.");
    }
}
