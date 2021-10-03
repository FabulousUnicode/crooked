using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scheuneHandler : MonoBehaviour
{
    public static bool key = false;
    public static bool kamera = false;
    public static bool dbaum = false;

    public static bool fertig = false;

    public TextAsset story;
    public Characters ca;


    public void handleInteraction(Item item)
    {
        if (item != null)
        {
            if (item.name == "barn_key" && !key)
            {
                key = true;
                FindObjectOfType<Dialog>().showText("Hier stinkt es und ich kann nichts sehen.");
            }
            if (item.name == "duftbaum" && !dbaum && key)
            {
                dbaum = true;
                FindObjectOfType<Dialog>().showText("Ok jetzt stinkt es nicht mehr, aber ich kann immer noch nichts sehen.");
            }
            if (item.name == "camera" && dbaum && key)
            {
                kamera = true;
                fertig = true;
                FindObjectOfType<Dialog>().showText("Ich hätte nicht versuchen sollen, mit 1000 Heliumballons an einem Lehnstuhl, zu fliegen");

                SceneManager.LoadScene("Barn");
            }
        }
        /*if (fertig)
        {
            kamera = true;
            fertig = true;
            FindObjectOfType<Dialog>().showText("Ich hätte nicht versuchen sollen, mit 1000 Heliumballons an einem Lehnstuhl, zu fliegen");

            SceneManager.LoadScene("Barn");
        }*/

    }

    public void Start()
    {
        if(!fertig)
        {
            return;
        }

        StartCoroutine(schwarz());
        
    }

    IEnumerator schwarz()
    {
        GameObject.Find("Schwarzblende").transform.position = new Vector3(0, 0, 0);
        yield return new WaitForSeconds(8.0f);
        GameObject.Find("Schwarzblende").transform.position = new Vector3(3000, 0, 0);
        yield return new WaitForSeconds(1.0f);

        FindObjectOfType<Dialog>().StartDialogue(story, ca);
    }
}