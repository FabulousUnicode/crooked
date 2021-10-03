using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{
    public Vector2 hotSpot = new Vector2(0, 0);
    public CursorMode cursorMode = CursorMode.Auto;
    public Sprite defaultCursor;

    void Update()
    {
        if(ItemInteraction.getLastUsed() != null)
        {
            Cursor.SetCursor(ItemInteraction.getLastUsed().icon.texture, hotSpot, cursorMode);
        }
        else
        {
            Cursor.SetCursor(defaultCursor.texture, hotSpot, cursorMode);
        }

    }
}
