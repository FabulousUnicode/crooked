using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotController : MonoBehaviour, IPointerClickHandler
{
    public Item item;
    public ItemInteraction interaction;
    public Inventory inventory;

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            Debug.Log(item.itemName + " Game Object Right Clicked!");
            if(interaction.getLastUsed() != null)
            {
                interaction.combineItems(item);
            }
            else
            {
                interaction.setLastUsed(item);
            }
        }

        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            if(item != null)
            {
                Debug.Log(item.itemName + " Game Object Left Clicked!");
                interaction.inspectItem(item);
            }
        }

        if (pointerEventData.button == PointerEventData.InputButton.Middle)
        {
            if (item != null)
            {
                Debug.Log(item.itemName + " Game Object Middle Clicked!");
                inventory.removeItem(item);
            }
        }
    }

    public void UpdateUI()
    {
        // finds image in slot
        Image displaySprite = transform.Find("Image").GetComponent<Image>();

        if (item)
        {
            displaySprite.sprite = item.icon;
            displaySprite.color = Color.white;
        }
        else
        {
            displaySprite.color = Color.clear;
            displaySprite.sprite = null;
        }
    }

    public void removeItemFromSlot() {
        item = null;
    }



}
