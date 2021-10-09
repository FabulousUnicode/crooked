using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicrowaveHandler : MonoBehaviour
{
    //private static List<Item> item_vorhanden;

    private static bool i1 = false;
    private static bool i2 = false;
    private static bool i3 = false;
    private static bool i4 = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void handleInteraction(Item item, Item lastUsed)
    {
        if(lastUsed.itemName == "Mehl")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(lastUsed);
            i1 = true;
        }
        else if(lastUsed.itemName == "Ei")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(lastUsed);
            i2 = true;
        }
        else if(lastUsed.itemName == "Mutterkorn")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(lastUsed);
            i3 = true;
        }
        else if(lastUsed.itemName == "Sojamilch")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(lastUsed);
            i4 = true;
        }
        else
        {
            FindObjectOfType<Dialog>().showText("Das ist nicht Mikrowellenfest.");
        }


        if (i1 && i2 && i3 && i4)
        {
            FindObjectOfType<Dialog>().showText("Alle Zutaten sind da. Der Kuchen ist fertig.");
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(ItemDatabaseInstance.getItemByName("cake"));
            FaceHandler.updateFace = true;
        }


    }
} 
