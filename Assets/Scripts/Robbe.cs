using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robbe : MonoBehaviour
{
    public void rumAnbieten(Item item)
    {
        if(item.name == "power_rum")
        {
            FindObjectOfType<Dialog>().showText("Ja! Ich habe gewonnen! Her mit der Karte! \n\nJane: Das kann nicht sein! Ihr seid die Loser, nicht ich... ich... glaub ... ich ... brauche mehr v...on dem Rum...");
            Item itemR = ItemDatabaseInstance.getItemByName("power_rum");
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(itemR);
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(GameObject.Find("Robbe").GetComponent<CharacterInfo>().character.list[0]);
        }
    }
}
