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
        if(item.itemName == "Schatzkarte")
        {
            FindObjectOfType<MapHandler>().handleInteraction();
        }
        else
        {
            FindObjectOfType<Dialog>().showText(item.description);
        }
        
    }

    public static void useItem(Item item)
    {
        
    }


    public static void useItemWithSelected(InteractableItem item)
    {
        if(item.item.itemName == "Mund" || item.item.itemName == "Auge")
        {
            BossHandler.handleInteraction(item.item, lastUsed); 
        }
        if(item.item.itemName == "Busch")
        {
            BushHandler.handleInteraction(item.item);
        }
        if(item.item.itemName == "Vorsprung")
        {
            HookHandler.handleInteraction(item.item, lastUsed);
        }
        if(item.item.itemName == "Seil")
        {
            RopeHandler.handleInteraction(item.item);
        }
        if(item.item.itemName == "Ablass-O-Mat")
        {
            AutomatHandler.handleInteraction(item.item, lastUsed);
        }
        if(item.item.itemName == "Klavier")
        {
            PianoHandler.handleInteraction(item.item, lastUsed);
        }
        if(item.item.itemName == "Spinnrad")
        {
            SpinwheelHandler.handleInteraction(item.item, lastUsed);
        }
        if(item.item.itemName == "Infiziertes_Korn")
        {
            FindObjectOfType<GrainHandler>().handleInteraction(item.item, lastUsed);
        }
        if(item.item.itemName == "Schublade")
        {
            SchubladenHandler.handleInteraction(item.item, lastUsed);
        }
        if (item.item.itemName == "Microwelle")
        {
            FindObjectOfType<MicrowaveHandler>().handleInteraction(item.item, lastUsed);
        }
        if(item.item.itemName == "Grab")
        {
            if(lastUsed != null)
            {
                FindObjectOfType<GraveHandler>().handleInteraction(item.item, lastUsed);
            }
            else
            {
                FindObjectOfType<GraveHandler>().handleInteractionNoItem();
            }
        }
        if (item.item.name == "bird")
        {
            if (lastUsed != null)
            {
                FindObjectOfType<BirdHandler>().handleInteraction(item.item, lastUsed);
            }
            else
            {
                FindObjectOfType<BirdHandler>().handleInteractionNoItem();
            }
        }
        if (item.item.itemName == "Glühwürmchen")
        {
            if (lastUsed != null)
            {
                FindObjectOfType<FirefliesHandler>().handleInteraction(item.item, lastUsed);
            }
            else
            {
                FindObjectOfType<FirefliesHandler>().handleInteractionNoItem();
            }
        }

        if (item.item.itemName == "Gitterstäbe")
        {
            if (lastUsed != null)
            {
                FindObjectOfType<BarsHandler>().handleInteraction(item.item, lastUsed);
            }
            else
            {
                FindObjectOfType<BarsHandler>().handleInteractionNoItem();
            }
        }
        
        if (item.item.itemName == "Schüssel")
        {
            if (lastUsed != null)
            {
                FindObjectOfType<BowlHandler>().handleInteraction(item.item, lastUsed);
            }
            else
            {
                FindObjectOfType<BowlHandler>().handleInteractionNoItem();
            }
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
            if (item.itemName == "Nähnadel" || lastUsed.itemName == "Nähnadel")
            {
                Inventory.instance.addItem(ItemDatabaseInstance.getItemByName("needle"));
            }
            resetLastUsed();

        }
        else
        {
            resetLastUsed();
            FindObjectOfType<Dialog>().showText("Das mach keinen Sinn!");
        }
    }
}
