using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Item/Range Item Data",fileName = "Range item data")]
public class RangeItemData : ItemsData
{
   [Header("Ranged Weapon Item Data")] 
   public float FireRate;
   public GameObject ProjectilePrefabs;
   public ItemsData ProjectileData;

   public void Fire(Vector3 spawnPos,Quaternion SpawnRotation,Character.Team team)
   {
      
   }
}
