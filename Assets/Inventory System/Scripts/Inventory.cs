using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventoryPanel;

    public static Inventory instance;

    [SerializeField] private List<Item> inventoryList = new List<Item>();
    [SerializeField] private List<InventorySlotController> slotList = new List<InventorySlotController>();


    public void Start()
    { 
        instance = this;
        updateInventorySlots();
    }

    public void updateInventorySlots()
    {
        int index = 0;
        foreach (Transform child in inventoryPanel.transform)
        {
            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if(index < inventoryList.Count)
            {
                slot.item = inventoryList[index];
            }
            slot.UpdateUI();
            index++;
        }
    }

    public void addItem(Item item)
    {
        inventoryList.Add(item);
        updateInventorySlots();
    }

    public void removeItem(Item item)
    {
        inventoryList.Remove(item);
        Debug.Log(item.itemName + "removed");

        foreach (Transform child in inventoryPanel.transform)
        {
            InventorySlotController slot = child.GetComponent<InventorySlotController>();

            if (slot.item == item)
            {
                slot.removeItemFromSlot();
            }

        }
        updateInventorySlots();
    }
}