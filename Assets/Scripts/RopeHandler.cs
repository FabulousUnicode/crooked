using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RopeHandler : MonoBehaviour
{

    public static int playerPos = 0;

    public Vector3 bottomPos;
    public Vector3 topPos;

    public static bool functionCalled = false;
    
    // Start is called before the first frame update
    void Start()
    {
        bottomPos = new Vector3(-75, -1015, 10);
        topPos = new Vector3(-100, -75, 10);

        if(General.getPreviousScene() == "Thorns")
        {
            playerPos = 0; 
        }
        if (General.getPreviousScene() == "Roof")
        {
            playerPos = 1;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Debug.Log(playerPos);
        if(functionCalled == true)
        {
            if(playerPos == 0)
            {
                updatePlayerPosition(topPos);
                GameObject.Find("Camera").transform.position = new Vector3(0, 329, -10);
            }
            if(playerPos == 1)
            {
                updatePlayerPosition(bottomPos);
                GameObject.Find("Camera").transform.position = new Vector3(0, -538, -10);
            }
            
        }
       
    }

    public void updatePlayerPosition(Vector3 dest)
    {
        Player.agent.SetDestination(dest);
        functionCalled = false;
    }

    public static void handleInteraction(Item item)
    {
        if(Player.agent.transform.position.y < -500)
        {
            playerPos = 0;
            functionCalled = true;
        }
        if(Player.agent.transform.position.y > -500)
        {
            playerPos = 1;
            functionCalled = true;
        }
        
    }
}
