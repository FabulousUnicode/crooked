using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BushHandler : MonoBehaviour
{
    public GameObject bush;
    private static bool active = true;

    public static void handleInteraction(Item item)
    {
        Debug.Log("dwaa");
        active = false;
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(active == false)
        {
            bush.SetActive(false);
        }
    }
}
