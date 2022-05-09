using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Melee Item Data",fileName = "Melee item data")]
public class MeleeItemData : ItemsData
{
    [Header("Melee Waepon Item Data")] public int Damege;
    public float Range;
    public float AttackRate;
    
}
