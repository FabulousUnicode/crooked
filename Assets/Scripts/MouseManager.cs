using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseManager : MonoBehaviour
{
    public Vector2 hotSpot = new Vector2(0, 0);
    public CursorMode cursorMode = CursorMode.Auto;
    public Sprite defaultCursor;

    public static bool updateActive = true;

    void Update()
    {
        if (updateActive)
        {
            if (ItemInteraction.getLastUsed() != null)
            {
                Cursor.SetCursor(ItemInteraction.getLastUsed().icon.texture, hotSpot, cursorMode);
            }
            else
            {
                Cursor.SetCursor(defaultCursor.texture, hotSpot, cursorMode);
            }
        }
    }

    internal static void disableUpdate()
    {
        if(ItemInteraction.getLastUsed() == null)
        {
            updateActive = false;
        }

    }

    internal static void enableUpdate()
    {
        updateActive = true;
    }
}
