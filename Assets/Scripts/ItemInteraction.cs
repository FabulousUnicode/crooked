using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    private static Item lastUsed;
   
    #region Utility
    public static void setLastUsed(Item item)
    {
        lastUsed = item;
        Debug.Log(lastUsed);
    }

    public static Item getLastUsed()
    {
        return lastUsed;
    }

    public static void resetLastUsed()
    {
        lastUsed = null;
    }
    #endregion

    public static void inspectItem(Item item)
    {
        Debug.Log(item.description);
    }

    public static void useItem(Item item)
    {
        
    }

    public static void useItemWithSelected(InteractableItem item)
    {
        if(item.item.itemName == "mouth" || item.item.itemName == "eyes")
        {
            BossHandler.handleInteraction(item.item, lastUsed); 
        }
    }

    public static void combineItems(Item item)
    {
        if(item.combinableWith == lastUsed || lastUsed == item.combinableWith)
        {
            Debug.Log("combine: " + lastUsed.name + "+" + item.itemName);
            Item combinedItem = ItemDatabaseInstance.getItemByName(item.combineResult.name);
            Inventory.instance.removeItem(item);
            Inventory.instance.removeItem(lastUsed);
            Inventory.instance.addItem(combinedItem);
            Debug.Log(lastUsed.name);
            resetLastUsed();

        }
        else
        {
            resetLastUsed();
            //return funny line
        }
    }
}
