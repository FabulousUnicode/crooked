using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurchUpdate : MonoBehaviour
{
    [SerializeField] private GameObject randy;
    [SerializeField] private GameObject matt;
    public static bool boss_active = false;
    // Start is called before the first frame update
    void Start()
    {
        if (boss_active == true)
        {
            randy.SetActive(true);
            matt.SetActive(false);
        }
    }

  
}
