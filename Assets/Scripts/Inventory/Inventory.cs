using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private ItemsData[] startItem;
    [SerializeField] private int InventorySize;
    private ItemSlot[] itemSlots;
    public InventoryUI UI;
    public static Inventory Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        itemSlots = new ItemSlot[InventorySize];
        for (int i = 0; i < itemSlots.Length; i++)
        {
            itemSlots[i] = new ItemSlot();
        }

        for (int i = 0; i < startItem.Length; i++)
        {
            AddItem(startItem[i]);
        }
    }

    public void AddItem(ItemsData item)
    {
        ItemSlot slot = FindAvaiableItemSlot(item);
        if (slot != null)
        {
            slot.Quantity++;
            UI.UpdateUI(itemSlots);
            return;
        }

        slot = GetEmptySlot();
        if (slot != null)
        {
            slot.Item = item;
            slot.Quantity = 1;
            
        }
        else
        {
            Debug.Log("Full Inventory");
            return;
        }
        UI.UpdateUI(itemSlots);
        
        
    }
    public void RemoveItem(ItemsData item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item)
            {
                RemoveItem(itemSlots[i]);
                return;
            }
        }
    }
    public void RemoveItem(ItemSlot slot)
    {
        if (slot == null)
        {
            Debug.Log("cant remove slot");
            return;
        }

        slot.Quantity--;
        if (slot.Quantity<=0)
        {
            slot.Item = null;
            slot.Quantity = 0;
            
        }
        UI.UpdateUI(itemSlots);
    }

    ItemSlot FindAvaiableItemSlot(ItemsData item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item&&itemSlots[i].Quantity<item.MaxStackSize)
            {
                return itemSlots[i];
            }
        }
        return null;
    }

    ItemSlot GetEmptySlot()
    {
        for (int i = 0; i <itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == null)
            {
                return itemSlots[i];
            }
        }
        
        return null;
    }

    public void UseItem(ItemSlot slot)
    {
        if (slot.Item is MeleeItemData || slot.Item is RangeItemData)
        {
            Player.Instance.EquipController.Equip(slot.Item);
        }
        else
        {
            if (slot.Item is FoodItemData)
            {
                FoodItemData food=slot.Item as FoodItemData;
                Player.Instance.Heal(food.HealthToGive);
                RemoveItem(slot);
            }
        }
    }

    public bool HasItem(ItemsData item)
    {
        for (int i = 0; i < itemSlots.Length; i++)
        {
            if (itemSlots[i].Item == item && itemSlots[i].Quantity > 0)
            {
                return true;
            }
        }
        return false;
    }
    
}
