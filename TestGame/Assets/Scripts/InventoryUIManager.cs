using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField]
    public GameObject inventory;
    [SerializeField]
    public GameObject itemSlotPrefab;
    private InventorySystem inventorySystem;

    public void Start() {
        inventorySystem = inventory.GetComponent<InventorySystem>();
    }

    public void OnUpdateInventory() {
        foreach(Transform t in transform) {
            Destroy(t.gameObject);
        }
        DrawInventory();
    }

    private void DrawInventory() {
        foreach (InventoryItem item in inventorySystem.inventory) {
            AddInventorySlot(item);
        }
    }

    private void AddInventorySlot(InventoryItem item) {
        if(item != null) {
            GameObject obj = Instantiate(itemSlotPrefab);
            obj.transform.SetParent(transform, false);

            SlotScript slot = obj.GetComponent<SlotScript>();
            slot.Set(item);
        }
    }
}
