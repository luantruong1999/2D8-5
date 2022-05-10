using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryToolTipUI : MonoBehaviour
{
    [SerializeField] private GameObject tooltipContainer;
    [SerializeField] private TextMeshProUGUI itemNameText;
    [SerializeField] private TextMeshProUGUI itemDescriptionText;

    public void SetToolTip(ItemsData item)
    {
        tooltipContainer.SetActive(true);
        itemNameText.text = item.DisplayName;
        itemDescriptionText.text = item.Description;

    }

    public void DisableToolTip()
    {
        tooltipContainer.SetActive(false);
    }
    
    
}
