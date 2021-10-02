using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flavia : MonoBehaviour
{
    public List<Item> items;
    public Item bone;

    public void flavia_combine(Item item)
    {
        GameObject invet = GameObject.Find("Inventory");


        if (bone == item)
        {
            FindObjectOfType<Dialog>().showText("Ja, das m�sste gehen. Aber so kann ich das nicht verarbeiten.");
        }
        else if(invet.GetComponent<Inventory>().searchItem(items[0].name) && invet.GetComponent<Inventory>().searchItem(items[1].name) && invet.GetComponent<Inventory>().searchItem(items[2].name))
        {
            FindObjectOfType<Dialog>().showText("So, das w�ren alle Zutaten. Bitte warte einen Augenblick.. ");
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(gameObject.GetComponent<CharacterInfo>().character.list[0]);
            foreach(var v in items)
            {
                if (v.name != "needle")
                    GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(v);
            }
        }
        else if(items.Contains(item))
        {
            FindObjectOfType<Dialog>().showText("Ja, das m�sste gehen... ");
        }
        else
        {
            FindObjectOfType<Dialog>().showText("Das geh�rt h�chstens auf den Sperrm�ll.");
        }
    }
}
