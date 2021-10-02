using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDatabaseInstance : MonoBehaviour
{
    public ItemDatabase items;
    private static ItemDatabaseInstance instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public static Item getItemByName(string name)
    {
        foreach(Item item in instance.items.database)
        {
            if (item.name == name)
            {
                return item;
            }
        }
        return null;
    }
}
