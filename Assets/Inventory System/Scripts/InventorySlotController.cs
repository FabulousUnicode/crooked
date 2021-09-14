using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlotController : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public Item item;
    public static Color standardColor = Color.black;
    public Color onHoverColor = Color.green;
    public Color onUseColor = Color.blue;
    public Color currentSelectedColor = Color.yellow;
    public GameObject hText;
    
    public static GameObject currentSelected;

    public static void resetCurrentSelected()
    {
        if(currentSelected != null)
        {
            currentSelected.GetComponent<Image>().color = standardColor;
            currentSelected = null;
        }

       
    }

   

    public void Awake()
    {
        gameObject.GetComponent<Image>().color = standardColor;
    }

    #region SlotInteractionHandler

    public void OnPointerDown(PointerEventData pointerEventData)
    {
        //event on left mouseclick
        if (pointerEventData.button == PointerEventData.InputButton.Left)
        {
            gameObject.GetComponent<Image>().color = onUseColor;

            if (item != null)
            {
                Debug.Log(item.itemName + " Game Object Left Clicked!");
                ItemInteraction.inspectItem(item);
                ItemInteraction.setLastUsed(null);
            }
        }

        /*
        //event on middle mouseclick
        if (pointerEventData.button == PointerEventData.InputButton.Middle)
        {
            if (item != null)
            {
                Debug.Log(item.itemName + " Game Object Middle Clicked!");
                Inventory.instance.removeItem(item);
                ItemInteraction.setLastUsed(null);
            }
        }
        */

        //event on right mouseclick to select item
        if (pointerEventData.button == PointerEventData.InputButton.Right)
        {
            gameObject.GetComponent<Image>().color = currentSelectedColor;

            if(currentSelected == null)
            {
                currentSelected = gameObject;
            }

            if(gameObject != currentSelected)
            {
                currentSelected.GetComponent<Image>().color = standardColor;
                currentSelected = gameObject;

            }

            if (ItemInteraction.getLastUsed() != null)
            {
                currentSelected.GetComponent<Image>().color = standardColor;
                currentSelected = null;
                ItemInteraction.combineItems(item);
                //Debug.Log(item.itemName + " Game Object Right Clicked!");
            }
            else
            {
                ItemInteraction.setLastUsed(item);
            }
        }
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        if(gameObject == currentSelected)
        {
            gameObject.GetComponent<Image>().color = currentSelectedColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = onHoverColor;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = onHoverColor;

        if(item != null)
        {
            hText.SetActive(true);
            hText.transform.GetChild(0).GetComponent<Text>().text = item.itemName;
            hText.transform.position = gameObject.transform.position + new Vector3(0, 100, 0);
        }
        
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (gameObject == currentSelected)
        {
            gameObject.GetComponent<Image>().color = currentSelectedColor;
        }
        else
        {
            gameObject.GetComponent<Image>().color = standardColor;
        }

        hText.SetActive(false);
    }
    #endregion

    #region UI Updates

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
            displaySprite.sprite = null;
            displaySprite.color = Color.clear;
        }
    }

    public void removeItemFromSlot() {
        item = null;
    }
    #endregion
}
