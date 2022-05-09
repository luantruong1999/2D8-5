using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EquipItem : MonoBehaviour
{
    [SerializeField] protected ItemsData item;

    public virtual void OnUse()
    {
        
    }
}
