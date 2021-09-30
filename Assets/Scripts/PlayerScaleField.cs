using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScaleField : MonoBehaviour
{

    public float maxScale_x = 25f;
    public float maxScale_y = -25f;

    public float minScale_x = 11f;
    public float minScale_y = -11f;

    public float scaleFactor;

    public float maxAgentSpeed = 300;
    public float minAgentSpeed = 70;


    public GameObject playerPos;


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

        if (playerPosAbs > 260)
        {

            playerPos.transform.localScale = new Vector3((float)Math.Pow((260 / playerPosAbs), 1.5f) * 25, -((float)Math.Pow((260 / playerPosAbs), 1.5f) * 25), 1);
            Player.agent.speed = (float) Math.Pow((playerPos.transform.localScale.x / 25), 1.5f) * 300;

        }
    }
}
