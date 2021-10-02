using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireFlLa : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if(LichtAnschalten.lichter < 4)
        {
            gameObject.transform.position += new Vector3(-2000.0f, 0.0f, 0.0f);
        }
    }
}
