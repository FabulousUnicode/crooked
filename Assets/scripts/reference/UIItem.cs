using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIItem : MonoBehaviour, IPointerDownHandler
{
    private Inventory selectedInventory;
    private UIInventory uiInventory = null;
    private int inSlot = 0;
    private Item item;
    private Item selectedItem;

    public UIInventory UiInventory => uiInventory;


    private void Awake()
    {
        selectedInventory = GameObject.FindWithTag("PlayerUI").GetComponent<Inventory>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            item = uiInventory.OwnerInv.GetItemFromIndex(inSlot);
            selectedItem = selectedInventory.GetItemFromIndex(0);

            if (item != null)
            {
                if (selectedItem != null)
                {
                    uiInventory.OwnerInv.SwapItems(selectedInventory, 0, inSlot);
                }
                else
                {
                    //selectedInventory.GiveItem(item);
                    //uiInventory.OwnerInv.RemoveItem(inSlot);
                    uiInventory.OwnerInv.SwapItems(selectedInventory, 0, inSlot);
                }
            }
            else if (selectedItem != null)
            {
                //uiInventory.OwnerInv.GiveItemAt(selectedItem, inSlot);
                //selectedInventory.RemoveItem(0);
                uiInventory.OwnerInv.SwapItems(selectedInventory, 0, inSlot);
            }
        }
        else
        {
            item = uiInventory.OwnerInv.GetItemFromIndex(inSlot);
            if (item != null)
            {
                UiInventory.OwnerInv.UseSlot(inSlot);
            } 
        }
    }

    public void SetUIInventory(UIInventory inv)
    {
        uiInventory = inv;
    }

    public void setInSlot(int slot)
    {
        inSlot = slot;
    }
}