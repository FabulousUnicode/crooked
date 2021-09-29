using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoHandler : MonoBehaviour
{

    public static bool stagelight_collectable = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject.Find("stagelight").GetComponent<InteractableItem>().item.collectable = stagelight_collectable;
    }

    public static void handleInteraction(Item item, Item lastUsed)
    {
        if(lastUsed.itemName == "Ablassbrief")
        {
            Inventory.instance.removeItem(lastUsed);
            FindObjectOfType<Dialog>().showText("der geist ist weg");
            stagelight_collectable = true;
        }
    }
}
