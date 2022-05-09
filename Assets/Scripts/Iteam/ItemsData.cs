using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Genenic Data",fileName = "Item Data")]
public class ItemsData : ScriptableObject
{
   public string DisplayName;
   public string Description;
   public Sprite icon;
   public int MaxStackSize=1;
   public GameObject EquipPrfab;
   

}
