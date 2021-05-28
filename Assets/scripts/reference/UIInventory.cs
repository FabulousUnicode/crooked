using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    private Image[] itemImages;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private Transform slotPanel = null;
    private int numberOfSlots = 1;
    private Inventory ownerInv = null;

    public Inventory OwnerInv => ownerInv;

    private void Awake()
    {
        //slotPrefab = Resources.Load<GameObject>("Prefabs/Slot");
        itemImages = new Image[numberOfSlots];

        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject instance = Instantiate(slotPrefab, Vector3.zero, Quaternion.identity, slotPanel);
            UIItem tmp = instance.GetComponentInChildren<UIItem>();
            tmp.SetUIInventory(this);
            tmp.setInSlot(i);

            foreach (Transform child in instance.transform)
            {
                itemImages[i] = child.GetComponent<Image>();
            }
        }
    }

    private void OnEnable()
    {
        ownerInv.OnItemChanged += HandleItemChanged;
    }

    private void OnDisable()
    {
        ownerInv.OnItemChanged -= HandleItemChanged;
    }

    public void UpdateSlot(int slot, Item item)
    {
        if (item != null)
        {
            itemImages[slot].color = Color.white;
            itemImages[slot].sprite = item.Icon;
        }
        else
        {
            itemImages[slot].color = Color.clear;
        }
    }

    private void HandleItemChanged(object sender, Inventory.ItemChangeArgs args)
    {
        UpdateSlot(args.Index, args.Item);
    }

    public void SetSlots(int i)
    {
        numberOfSlots = i;
    }

    public void SetInventory(Inventory inv)
    {
        ownerInv = inv;
    }
}