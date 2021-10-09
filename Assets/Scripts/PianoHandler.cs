using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoHandler : MonoBehaviour
{
    [SerializeField] private GameObject music;
    private bool keys = false;
    public static bool stagelight_collectable = false;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("stagelight") != null)
        {
            GameObject.Find("stagelight").GetComponent<InteractableItem>().item.collectable = stagelight_collectable;
        }

        if (stagelight_collectable == true && keys == false)
        {
            music.SetActive(true);
            keys = true;
        }
    }

    public static void handleInteraction(Item item, Item lastUsed)
    {
        if(lastUsed.itemName == "Ablassbrief")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(lastUsed);
            FindObjectOfType<Dialog>().showText("Das wird die arme Seele besänftigen");
            stagelight_collectable = true;
        }
    }
}
