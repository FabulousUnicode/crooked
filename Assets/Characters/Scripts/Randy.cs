using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Randy : MonoBehaviour
{

    public void verhaften(Item item)
    {
        if (item == null)
        {
            return;
        }

        if(item.name == "tape_recorder")
        {
            if(Mary.recordet)
            {
                FindObjectOfType<RandyStatus>().anzeige();
                FindObjectOfType<RandyStatus>().maryweg();
                ScenenChange.remove += ("mary" + ",");
                FindObjectOfType<Dialog>().showText("Ich muss los.");
            }
            else
            {
                FindObjectOfType<Dialog>().showText("Komm wieder wenn du Beweise hast.");
            }
        }
    }
}
