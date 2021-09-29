using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookHandler : MonoBehaviour
{
    public GameObject achorPoint;

    public GameObject rope;
    private static bool ropeActive = false;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(ropeActive == true)
        {
            rope.SetActive(true);
            achorPoint.SetActive(false);
            Player.agent.ResetPath();
        }
    }

    public static void handleInteraction(Item item, Item lastUsed)
    {
        if(lastUsed.itemName == "Enterhaken")
        {
            Debug.Log("setting rope active");
            ropeActive = true; 
        }
    }
}
