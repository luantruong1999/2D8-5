using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

 class InventorySlotUI : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] private Image icon;
    [SerializeField] private TextMeshProUGUI quantityText;
    private ItemSlot itemSlot;

    public void SetItemSlot(ItemSlot slot)
    {
        itemSlot = slot;
        if (slot.Item == null)
        {
            icon.enabled = false;
            quantityText.text = string.Empty;
        }
        else
        {
            icon.enabled = true;
            icon.sprite = slot.Item.icon;
            quantityText.text = itemSlot.Quantity > 1 ? slot.Quantity.ToString() : string.Empty;
            
        }
        
        
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (itemSlot.Item != null)
        {
            Inventory.Instance.UseItem(itemSlot);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (itemSlot.Item != null)
        {
            Inventory.Instance.UI.ToolTipUI.SetToolTip(itemSlot.Item);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (itemSlot.Item != null)
        {
            Inventory.Instance.UI.ToolTipUI.DisableToolTip();
        }
    }
}
