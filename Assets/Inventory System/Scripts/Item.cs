using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : ScriptableObject
{
    public string itemName;
    public Sprite icon;
    [TextArea(10,10)]
    public string description;
    public bool combinable;
    public Item combinableWith;
    public Item combineResult;
}
