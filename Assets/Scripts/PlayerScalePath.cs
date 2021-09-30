using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScalePath : MonoBehaviour
{

    public float maxScale_x = 19f;
    public float maxScale_y = -19f;

    public float minScale_x = 4.5f;
    public float minScale_y = -4.5f;

    public float scaleFactor;

    public float maxAgentSpeed = 300;
    public float minAgentSpeed = 70;


    public GameObject playerPos;

    // min y pos = -480    -> scale = ( 29 / -29 )

    //unteschied s1 - s2   -> 

    // schnitt bei  y = -230 -> scale = (19 / -19)

    // bei �bergang woods y = 65   -> scale = (7 / -7)



    // Start is called before the first frame update
    void Start()
    {
        scaleFactor = maxScale_x - minScale_x;
    }

    // Update is called once per frame
    void Update()
    {

        float playerPosAbs = playerPos.transform.position.y + 540;
        float playerSpeed = Player.agent.speed;

        Debug.Log(playerPosAbs);

        if (playerPosAbs > 330)
        {

            playerPos.transform.localScale = new Vector3((float) Math.Pow((330 / playerPosAbs), 1.5f) * 19 , - ((float)Math.Pow((330 / playerPosAbs), 1.5f) * 19), 1);
            //playerPos.transform.localScale = new Vector3((float)(Math.Log(1.5f) * (330 / playerPosAbs)) * 19  , - (float)(Math.Log(1.5f) * (330 / playerPosAbs)) * 19, 1);
            Player.agent.speed = (float) Math.Pow(playerPos.transform.localScale.x / 19, 1.5f) * 300;
            
        }
    }
}
