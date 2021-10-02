using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdHandler : MonoBehaviour
{
    public GameObject bird;
    public GameObject ancient_bird;
    public void handleInteraction(Item item, Item lastUsed)
    {
        if(lastUsed.itemName == "Schaufel")
        {
            FindObjectOfType<Dialog>().showText("Bonk!");
            bird.SetActive(false);
            ancient_bird.SetActive(true);
        }
        else
        {
            FindObjectOfType<Dialog>().showText("Er hat mich angegriffen.");
            Player.agent.SetDestination(new Vector3(235, -305, 0));
        }
    }

    public void handleInteractionNoItem()
    {
        FindObjectOfType<Dialog>().showText("Er hat mich angegriffen.");
        Player.agent.SetDestination(new Vector3(235, -305, 0));
    }
}
