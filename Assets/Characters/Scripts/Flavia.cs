using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flavia : MonoBehaviour
{
    public List<Item> items;
    public Item bone;


    private static bool i1 = false;
    private static bool i2 = false;
    private static bool i3 = false;


    public void flavia_combine(Item item)
    {
        GameObject invet = GameObject.Find("Inventory");


        if(item == null)
        {
            FindObjectOfType<Dialog>().showText("Du musst mir auch was anbieten");
            return;
        }

        if (bone == item) //Fu�knochen
        {
            FindObjectOfType<Dialog>().showText("Ja, das m�sste gehen. Aber so kann ich das nicht verarbeiten.");
        }
        else if(item == items[0] && !i1)    //Knochenstaub
        {
            i1 = true;
            FindObjectOfType<Dialog>().showText("Ja, das m�sste gehen... ");
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(item);
        }
        else if (item == items[1] && !i2) //Marker
        {
            i2 = true;
            FindObjectOfType<Dialog>().showText("Ja, das m�sste gehen... ");
        }
        else if (item == items[2] && !i3)   //uran
        {
            i3 = true;
            FindObjectOfType<Dialog>().showText("Ja, das m�sste gehen... ");
        }
        else
        {
            FindObjectOfType<Dialog>().showText("Das geh�rt h�chstens auf den Sperrm�ll.");
        }


        if (i1 && i2 && i3)
        {
            FindObjectOfType<Dialog>().showText("So, das w�ren alle Zutaten. Bitte warte einen Augenblick.. ");
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(gameObject.GetComponent<CharacterInfo>().character.list[0]);
        }
    }
}
