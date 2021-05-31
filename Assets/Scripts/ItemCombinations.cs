using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCombinations : MonoBehaviour
{
    public static Item checkForValidCombination(Item item1, Item item2)
    {
        if(item1.name == "Stone" && item2.name == "Knife")
        {
            Item item = ItemDatabaseInstance.getItemByName("Dull Knife");
            Debug.Log("found: " + item.itemName);
            return item;
        }

        return null;
    }


}
