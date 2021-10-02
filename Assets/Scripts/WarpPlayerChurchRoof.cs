using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarpPlayerChurchRoof : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Player.agent.Warp(new Vector3(-528, -487, 0));
    }
}
