using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceHandler : MonoBehaviour
{
    public static bool updateFace = false;
    public GameObject face;
    // Start is called before the first frame update
    void Start()
    {
        if (updateFace == true)
        {
            face.SetActive(true);
        }
    }
}
