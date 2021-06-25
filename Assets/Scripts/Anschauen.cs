using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anschauen : MonoBehaviour
{
    Vector3 ursprung;
    bool anschauend;
    public float scale;

    void Start()
    {
        ursprung = gameObject.transform.position;
        anschauend = false;
    }

    public void AnschauenStart()
    {
        if (anschauend) return;
        gameObject.transform.position = new Vector3(0f, 0f, 0f);
        gameObject.transform.localScale += new Vector3(scale, scale, 1);
        anschauend = true;
    }

    public void AnschauenEnde()
    {
        if (!anschauend) return;
        gameObject.transform.position = ursprung;
        gameObject.transform.localScale -= new Vector3(scale, scale, 1);
        anschauend = false;
    }
}
