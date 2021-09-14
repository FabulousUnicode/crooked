using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject inventoryPanel;
    [SerializeField] private GameObject inventoryButton;

    public static Inventory instance;

    [SerializeField] private static List<Item> inventoryList = new List<Item>();
    [SerializeField] private List<InventorySlotController> slotList = new List<InventorySlotController>();

    public void Start()
    {
        
        instance = this;
        updateInventorySlots();
        toggleInventory();
    }

    public void updateInventorySlots()
    {
        int index = 0;
        if (inventoryPanel == null)
        {
            inventoryPanel = GameObject.Find("InventoryPanel");
        }
        foreach (Transform child in inventoryPanel.transform)
        {
            //print("CP1");
            InventorySlotController slot = child.GetComponent<InventorySlotController>();
            slot.item = null;

            if(index < Inventory.inventoryList.Count)
            {
                slot.item = Inventory.inventoryList[index];
            }
            slot.UpdateUI();
            index++;
        }
    }

    public void toggleInventory()
    {
        inventoryPanel.SetActive(!inventoryPanel.activeSelf);
        if(CameraController.getInventoryOpen() == false)
        {
            CameraController.setInventoryOpen(true);
        }
        else
        {
            CameraController.setInventoryOpen(false);
        }
    }

    public void addItem(Item item)
    {
        Inventory.inventoryList.Add(item);
        updateInventorySlots();
        
    }

    public void removeItem(Item item)
    {
        Inventory.inventoryList.Remove(item);
        updateInventorySlots();


    }

    public bool searchItem(string item)
    {
        if(Inventory.inventoryList.Find(x=>x.name.Equals(item)) != null)
        {
            return true;
        }
        return false;
    }
}