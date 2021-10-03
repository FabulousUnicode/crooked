using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LichtAnschalten : MonoBehaviour
{
    public static int lichter = 0;
    public static bool aktiviert = true;

    public static bool[] lampen = new bool[4] {false, false, false, false};


    public void anschalten()
    {
        if (!aktiviert)
        {
            if (lichter >= 4)
            {
                ScenenChange.add += ("lantern" + ",");
                GameObject asd = GameObject.Find("Laterne").transform.GetChild(0).gameObject;

                asd.SetActive(true);

                aktiviert = true;
                print("Lichter an");

                ScenenChange.add += ("mottenkugel" + ",");
            }
        }
        else
        {
            FindObjectOfType<Dialog>().showText("Die Lichter wurden schon angemacht. Ich denke sie sollten auch an bleiben.");
        }

    }

    void Start()
    {
        /*if(aktiviert)
        {
            GameObject asd = GameObject.Find("Laterne").transform.GetChild(0).gameObject;



            //GameObject.Find("Laterne").GetComponent<Licht>().aktivieren();

            print(lampen[GameObject.Find("Laterne").GetComponent<Licht>().nummer]);

            if(lampen[GameObject.Find("Laterne").GetComponent<Licht>().nummer])
            {
                asd.SetActive(true);
            }
        }*/
        
    }

    void Update()
    {
    }
        
}
