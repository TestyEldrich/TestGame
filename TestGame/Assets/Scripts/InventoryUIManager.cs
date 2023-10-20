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
    private bool isHidden = false;

    public void Start() {
        inventorySystem = inventory.GetComponent<InventorySystem>();
        ToggleInventory();
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

    public void ToggleInventory() {
        if (!isHidden) {
            GameObject.Find("Inventory Bar").transform.localScale = new Vector3(0, 0, 0);
            GameObject.Find("Trash").transform.localScale = new Vector3(0, 0, 0);
            isHidden = true;
        }
        else if (isHidden) {
            GameObject.Find("Inventory Bar").transform.localScale = new Vector3(1, 1, 1);
            GameObject.Find("Trash").transform.localScale = new Vector3(1, 1, 1);
            isHidden = false;
        }
    }
}
