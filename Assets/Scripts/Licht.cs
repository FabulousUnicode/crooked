using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licht : MonoBehaviour
{
    public int nummer;
    public Item item;
    public string lampName;


    public void aktivieren(Item lastUsed)
    {
        if (!LichtAnschalten.lampen[nummer])
        {
            GameObject inven = GameObject.Find("Inventory");

            if(inven.GetComponent<Inventory>().searchItem(item.name) && lastUsed == item)
            {
                gameObject.transform.GetChild(0).gameObject.SetActive(true);

                LichtAnschalten.lampen[nummer] = true;

                inven.GetComponent<Inventory>().removeItem(item);

                if(item.name == "uranium_rods")
                {
                    inven.GetComponent<Inventory>().addItem(item);
                }

                FindObjectOfType<Dialog>().showText("Ok das scheint zu passen.");

                LichtAnschalten.lichter++;
            }
            else
            {
                FindObjectOfType<Dialog>().showText("Das funktioniert nicht, ich brauche eine andere Lichtquelle.");
            }

        }
        else
        {
            print("bereits aktiviert");
        }
           
    }

    void Start()
    {
        if (LichtAnschalten.lampen[nummer])
        {
            GameObject asd = gameObject.transform.GetChild(0).gameObject;

            asd.SetActive(true);
        }
    }
}
