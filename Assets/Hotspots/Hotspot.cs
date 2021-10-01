using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hotspot : ScriptableObject
{
    public string h_name;

    public bool walkTo;

    [TextArea(4, 2)]
    public string use;

    [TextArea(4, 2)]
    public string inspect;

    public List<Item> specialInteraction;

    [TextArea(4, 2)]
    public List<string> specialInteractionStrings;




}
