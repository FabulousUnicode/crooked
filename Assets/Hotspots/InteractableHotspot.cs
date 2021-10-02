using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableHotspot : MonoBehaviour
{
    public Hotspot hotspot;


    public string getUseText()
    {
        return hotspot.use;
    }

    public string getInspectText()
    {
        return hotspot.inspect;
    }
}
