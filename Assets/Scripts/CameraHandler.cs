using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CameraHandler : MonoBehaviour
{

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        if(General.getPreviousScene() == "Thorns")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, -538, -10);
            agent.Warp(new Vector3(525, -1000, 0));
        }

        else if (General.getPreviousScene() == "Thorns1")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(91, -116, 0));
        }

        else if (General.getPreviousScene() == "Church")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(-27, -268, 0));
        }

        else if (General.getPreviousScene() == "Church Roof")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 329, -10);
            agent.Warp(new Vector3(539, 96, 0));
        }

        else if (General.getPreviousScene() == "Path")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(809, -489, 0));
        }

        else if (General.getPreviousScene() == "Path1")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(-809, -489, 0));
        }

        else if (General.getPreviousScene() == "Farm")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(259, -113, 0));
        }

        else if (General.getPreviousScene() == "Shipwreck")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(-834, -477, 0));
        }

        else if (General.getPreviousScene() == "Camp")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(530, 114, 0));
        }

        else if (General.getPreviousScene() == "Woods")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            Debug.Log(agent);
            agent.Warp(new Vector3(-395, -7, 0));
        }

        else if (General.getPreviousScene() == "Shop")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(-395, -7, 0));
        }

        else if (General.getPreviousScene() == "Randy's Shack")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(707, 199, 0));
        }

        else if (General.getPreviousScene() == "Tunnel")
        {
            Debug.Log("Previous Scene: " + General.getPreviousScene());
            GameObject.Find("Camera").transform.position = new Vector3(0, 0, -10);
            agent.Warp(new Vector3(358, 259, 0));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
