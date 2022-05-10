using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;


public class WorldItem : MonoBehaviour
{
    [SerializeField] private float spawnForce;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private AudioClip pickupFSX;

    private ItemsData itemToGive;

    private void Start()
    {
        Rigidbody2D rig = GetComponent<Rigidbody2D>();
        rig.AddForce(Random.insideUnitCircle*spawnForce,ForceMode2D.Impulse);
    }

    public void SetItem(ItemsData item)
    {
        itemToGive = item;
        spriteRenderer.sprite = item.icon;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            Inventory.Instance.AddItem(itemToGive);
            AudioManager.Instance.PlayPlayerAudio(pickupFSX);
            Destroy(gameObject);
        }
    }
}
