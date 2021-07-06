using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenenChange : MonoBehaviour
{
    public string scene;
    public static string remove;
    public string destinationName;


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
    }


    public void wechsel()
    {
        SceneManager.LoadScene(scene);
    }
}
