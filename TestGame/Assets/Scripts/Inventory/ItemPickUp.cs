using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    public string collisionTag;
    [SerializeField]
    public InventoryItemData referenceItem;
    private InventorySystem inventorySystem;
    [SerializeField]
    private GameObject inventory;

    private void Start() {
        inventory = GameObject.Find("Inventory");
        inventorySystem = inventory.GetComponent<InventorySystem>();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.tag == collisionTag) {
            inventorySystem.Add(referenceItem);
            Destroy(gameObject);
        }
    }
}
