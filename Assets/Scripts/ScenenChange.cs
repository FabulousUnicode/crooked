using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenenChange : MonoBehaviour
{
    public string scene;
    public static string remove;
    public string destinationName;

    public static string add;


    public void Start()
    {
        remove += "";
        string[] subs = remove.Split(',');


        foreach (var sub in subs)
        {
            GameObject obj = GameObject.Find(sub);
            if(obj != null)
            {
               Destroy(obj);
            }
        }

        add += "";
        string[] adds = add.Split(',');

        print(add);

        foreach(var a in adds)
        {
            GameObject obj = GameObject.Find(a);
            if (obj != null)
            {
                obj.SetActive(true);
            }
        }

    }


    public void wechsel()
    {
        GameObject.Find("DialogFeld").transform.GetChild(1).gameObject.SetActive(false);
        SceneManager.LoadScene(scene);
    }
}
