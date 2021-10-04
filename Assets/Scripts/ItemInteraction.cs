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
            if (lastUsed != null)
            {
                AutomatHandler.handleInteraction(item.item, lastUsed);
            }
            else
            {
                AutomatHandler.handleInteractionNoItem(item.item);
            } 
        }
        if(item.item.itemName == "Klavier")
        {
            PianoHandler.handleInteraction(item.item, lastUsed);
        }
        if(item.item.itemName == "Spinnrad")
        {
            SpinwheelHandler.handleInteraction(item.item, lastUsed);
        }
        if(item.item.itemName == "Infiziertes Korn")
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
        if (item.item.name == "lamp0" || item.item.name == "lamp1" || item.item.name == "lamp2" || item.item.name == "lamp3")
        {
            FindObjectOfType<Licht>().aktivieren(lastUsed);
        }
        if (item.item.itemName == "Sense")
        {
            FindObjectOfType<senseHandler>().handleInteraction(lastUsed);
        }
        if (item.item.itemName == "Duftbaum")
        {
            FindObjectOfType<duftbaumHandler>().handleInteraction(lastUsed);
        }

        if (item.item.itemName == "Scheunentor")
        {
            FindObjectOfType<scheuneHandler>().handleInteraction(lastUsed);
        }
        if (item.item.name == "bugs")
        {
            FindObjectOfType<BugsHandler>().handleInteraction(item.item,lastUsed);
        }

        if (item.item.itemName == "Gestrüpp")
        {
            if (lastUsed != null)
            {
                FindObjectOfType<TreasureHandler>().handleInteraction(item.item, lastUsed);
            }
            else
            {
                FindObjectOfType<TreasureHandler>().handleInteractionNoItem();
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
            else if (item.name == "coffee_grinder" || lastUsed.name == "coffee_grinder")
            {
                Inventory.instance.addItem(ItemDatabaseInstance.getItemByName("coffee_grinder"));
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
