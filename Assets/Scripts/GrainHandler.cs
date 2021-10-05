using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrainHandler : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject obj = GameObject.Find("infected_grain_2");
        if(RandyStatus.huette)
        {
            
            if (obj != null)
            {
                gameObject.transform.position = new Vector3(-456.0f, -72.0f, -0.1f);
            }
        }
        else if(obj != null)
        {
            gameObject.transform.position = new Vector3(-2456.0f, -72.0f, -0.1f);
        }
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
                ScenenChange.remove += ("infected_grain_2" + ",");
            }
            else
            {
                FindObjectOfType<Dialog>().showText("Mit einer Mühle könnte ich das mahlen");
            }
        }
        else
        {
            print("passt");
        }
    }
}
