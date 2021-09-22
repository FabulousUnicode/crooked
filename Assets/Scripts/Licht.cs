using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Licht : MonoBehaviour
{
    public Sprite standard;
    public Sprite aktiv;
    public int nummer;

    public Item item;
    public string lampName;

    private SpriteRenderer spriteRenderer;

    public void aktivieren()
    {
        if (!LichtAnschalten.lampen[nummer])
        {
            GameObject inven = GameObject.Find("Inventory");

            if(inven.GetComponent<Inventory>().searchItem(item.name))
            {
                spriteRenderer = GetComponent<SpriteRenderer>();
                spriteRenderer.sprite = aktiv;
                LichtAnschalten.lampen[nummer] = true;

                inven.GetComponent<Inventory>().removeItem(item);

                FindObjectOfType<Dialog>().showText("Ok das scheint zu passen.");

                LichtAnschalten.lichter++;
            }
            else
            {
                FindObjectOfType<Dialog>().showText("Hier scheinen " + lampName + " zu fehlen.");
            }

        }
        else
        {
            print("bereits aktiviert");
        }
           
    }

    void Start()
    {
        if(LichtAnschalten.aktiviert)
        {
            GameObject asd = gameObject.transform.GetChild(0).gameObject;

            asd.SetActive(true);

            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = aktiv; 
        }
        else if (LichtAnschalten.lampen[nummer])
        {
            //GameObject asd = gameObject.transform.GetChild(0).gameObject;

            //asd.SetActive(true);

            spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.sprite = aktiv;
        }
    }
}
