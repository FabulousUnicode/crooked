using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrainHandler : MonoBehaviour
{
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
        if (RandyStatus.feld_beine)
        {
            ScenenChange.remove += (gameObject.name + ",");

            FindObjectOfType<RandyStatus>().korngesammelt();

            Destroy(gameObject);
        }
        else if(RandyStatus.huette)
        {
            if(lastUsed.itemName == "Kaffeemühle")
            {
                GameObject.Find("Inventory").GetComponent<Inventory>().addItem(ItemDatabaseInstance.getItemByName("flour"));
                GameObject.Find("Inventory").GetComponent<Inventory>().addItem(ItemDatabaseInstance.getItemByName("mutterkorn"));
                Destroy(gameObject);
            }
            else
            {
                FindObjectOfType<Dialog>().showText("Mit einer Mühle könnte ich das mahlen");
            }
        }
    }
}
