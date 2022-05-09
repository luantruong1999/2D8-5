using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class EquipController : MonoBehaviour
{
    [SerializeField]private ItemsData test;
    private EquipItem curEquipItem;
    private GameObject curEquipGameObject;
    private bool useInput;

    [Header("Compoments")] [SerializeField]
    private Transform equipObjectOrigin;

    [SerializeField] private MouseUtilities mouseUtilities;

    private void Start()
    {
        Equip(test);
    }

    private void Update()
    {
        Vector2 mouseDir = mouseUtilities.GetMouseDirection(transform.position);
        transform.up = mouseDir;
        if (HasItemEquip())
        {
            if (useInput && EventSystem.current.IsPointerOverGameObject() == false)
            {
                
                curEquipItem.OnUse();
            }
        }
    }

    public void Equip(ItemsData item)
    {
        if (HasItemEquip())
        {
            UnEquip();
        }

        curEquipGameObject = Instantiate(item.EquipPrfab, equipObjectOrigin);
        curEquipItem = curEquipGameObject.GetComponent<EquipItem>();
        
    }

    public void UnEquip()
    {
        if (curEquipGameObject != null)
        {
            Destroy(curEquipGameObject);
        }

        curEquipItem = null;
    }

    public bool HasItemEquip()
    {
        return curEquipItem != null;
    }

    public void OnUseInput(InputAction.CallbackContext context)
    {
        
        if (context.phase == InputActionPhase.Performed)
        {
            useInput = true;
            
            
        }

        if (context.phase == InputActionPhase.Canceled)
        {
            useInput = false;
        }
    }
    
}
