using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichtAnschalten : MonoBehaviour
{
    public static int lichter = 0;
    public static bool aktiviert = false;

    public static bool[] lampen;


    public void anschalten()
    {
        if (!aktiviert)
        {
            if (lichter >= 2)
            {
                ScenenChange.add += ("lantern" + ",");
                GameObject asd = GameObject.Find("Laterne").transform.GetChild(0).gameObject;

                asd.SetActive(true);

                aktiviert = true;
            }
        }
        else
        {
            FindObjectOfType<Dialog>().showText("Die Lichter wurden schon angemacht. Ich denke sie sollten auch an bleiben.");
        }

    }

    void Start()
    {
        if(aktiviert)
        {
            GameObject asd = GameObject.Find("Laterne").transform.GetChild(0).gameObject;

            asd.SetActive(true);

            GameObject.Find("Laterne").GetComponent<Licht>().aktivieren();
        }
        
    }
        
}
