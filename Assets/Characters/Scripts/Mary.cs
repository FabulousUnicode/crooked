using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mary : MonoBehaviour
{
    public Item schatz;
    public Item mutterkorn;
    public Item Recorder;
    public static bool schatz_ab = false;
    public static bool sus = false;
    public static bool recordet = false;


    public void itemsAnbieten(Item item)
    {
        if(item == schatz)
        {
            FindObjectOfType<Dialog>().showText("Das ist alles? Haha, ich wusste doch, es lohnt sich nicht einen Finger zu kr�mmen. Aber gute Arbeit. An dir ist ein guter Seer�uber verloren gegangen.");
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(schatz);
            schatz_ab = true;
        }
        else if(schatz_ab && item != mutterkorn && !sus)
        {
            FindObjectOfType<Dialog>().showText("Ich vertraue niemandem einfach so. Gib mir einen Grund dazu, dann sprechen wir �ber Gesch�ftliches. ");
        }
        else if(schatz_ab && item == mutterkorn)
        {
            FindObjectOfType<Dialog>().showText("Gute Ware. Ich gebe dir gleich morgen deine Bezahlung. Vielleicht auch �bermorgen, da muss ich mal sehen...");
            GameObject.Find("Inventory").GetComponent<Inventory>().removeItem(mutterkorn);
            sus = true;
        }
        else if(sus && item == Recorder)
        {
            FindObjectOfType<Dialog>().showText("Jemanden wie dich k�nnten wir in unserer unserer kriminellen Regenbogeneinhorngang gut gebrauchen. <<click>> ... das h�rt sich nach einem Recorder an. Komm sp�ter wieder dann erkl�r ich alles.");
            recordet = true;
        }
    }
}
