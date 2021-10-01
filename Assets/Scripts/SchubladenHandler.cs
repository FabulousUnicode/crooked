using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SchubladenHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    internal static void handleInteraction(Item item, Item lastUsed)
    {
        if (lastUsed.itemName == "Schlüssel")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(lastUsed);
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(ItemDatabaseInstance.getItemByName("tape_recorder"));
            FindObjectOfType<Dialog>().showText("Der ist super zur Beweisaufnahme.");
        }
    }
}
