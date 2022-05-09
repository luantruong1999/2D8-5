using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Food Item Data",fileName = "food item data")]
public class FoodItemData : ItemsData
{
    [Header("Food Item Data")] public int HealthToGive;
    
}
