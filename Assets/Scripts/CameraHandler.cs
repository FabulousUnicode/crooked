using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        if(General.getPreviousScene() == "Thorns")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, -538, -10);
            Player.agent.Warp(new Vector3(525, -1000, 0));
        }

        if(General.getPreviousScene() == "Church")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            Player.agent.Warp(new Vector3(-27, -268, 0));
        }

        if (General.getPreviousScene() == "Church Roof")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 329, -10);
            Player.agent.Warp(new Vector3(539, 96, 0));
        }


    }

    // Update is called once per frame
    void Update()
    {

    }
}
