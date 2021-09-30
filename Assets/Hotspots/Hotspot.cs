using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot : ScriptableObject
{
    public string h_name;

    public bool walkTo;

    [TextArea(10, 10)]
    public string use;

    [TextArea(10, 10)]
    public string inspect;

}
