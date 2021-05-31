using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{

    private Inventory inventory;
    private  Item lastUsed;
   
    #region Utility
    public void setLastUsed(Item item)
    {
        lastUsed = item;
    }

    public Item getLastUsed()
    {
        return lastUsed;
    }

    public void resetLastUsed()
    {
        lastUsed = null;
    }
    #endregion

    public void inspectItem(Item item)
    {
        Debug.Log(item.description);
    }

    public void useItem(Item item)
    {
        //do something
    }

    public void combineItems(Item item)
    {
        Debug.Log("combine: " + lastUsed.name + "+" + item.itemName);

       
        Item result = ItemCombinations.checkForValidCombination(lastUsed, item);
        Debug.Log(result.itemName + "" + result.description);
        Inventory.instance.removeItem(item);
        Inventory.instance.removeItem(lastUsed);
        Inventory.instance.addItem(result);
        Debug.Log(lastUsed.name);
        resetLastUsed(); 
    }
}
