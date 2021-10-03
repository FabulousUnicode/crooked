using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FarmStartDialog : MonoBehaviour
{
    public static bool trigger = false;
    public static bool namebekannt = false;
    public TextAsset story;
    public Item coin;
    public Characters ca;
    public GameObject bild;

    public Sprite selfie;
    public Sprite nameS;
    public Image myIMGcomponent;
    private bool bstatus = true;
    private static bool drehen = false;

    void Update()
    {
        if(!trigger)
        {
            FindObjectOfType<Dialog>().StartDialogue(story, ca);
            trigger = true;
            GameObject.Find("Inventory").GetComponent<Inventory>().addItem(coin);
        }
    }

    public void bildzeigen(float zeit = 0)
    {
        bild.SetActive(true);

        if(zeit != 0)
        {
            StartCoroutine(bwait(zeit));
        }

    }

    IEnumerator bwait(float zeit)
    {
        yield return new WaitForSeconds(zeit);
        bildschliessen();
        drehen = true;
    }

    public void bildschliessen()
    {
        bild.SetActive(false);
    }

    public void bilddrehen()
    {
        if(drehen)
        {
            if(bstatus)
            {
                myIMGcomponent.sprite = nameS;
                bstatus = false;
                namebekannt = true;
            }
            else
            {
                myIMGcomponent.sprite = selfie;
                bstatus = true;
            }
        }
        
    }
}
