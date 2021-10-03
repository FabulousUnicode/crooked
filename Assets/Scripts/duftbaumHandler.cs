using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duftbaumHandler : MonoBehaviour
{
    public void handleInteraction(Item item)
    {
        if (item.name == "signed_scythe")
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(ItemDatabaseInstance.getItemByName("duftbaum"));
            Destroy(gameObject);
            ScenenChange.remove += (gameObject.name + ",");

            FindObjectOfType<Dialog>().showText("Damit sollte jeder Gestank verschwinden.");
        }
        else
        {
            FindObjectOfType<Dialog>().showText("Am besten fälle ich den mit der Sense.");
        }
    }
}
