using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class senseHandler : MonoBehaviour
{
    public void handleInteraction(Item item)
    {
        if(item.name == "permanent_marker" && FarmStartDialog.namebekannt)
        {
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(ItemDatabaseInstance.getItemByName("signed_scythe"));
            Destroy(gameObject);
            ScenenChange.remove += (gameObject.name + ",");

            FindObjectOfType<Dialog>().showText("So, jetzt kann ich die Sense endlich tragen.");
        }
        else if(item.name == "permanent_marker")
        {
            FindObjectOfType<Dialog>().showText("Ich muss meinen Namen herausfinden");
        }
        else
        {
            FindObjectOfType<Dialog>().showText("Ich denke darauf muss mein Name stehen.");
        }
    }
}
