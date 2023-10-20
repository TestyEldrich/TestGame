using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DeleteOnDrop : MonoBehaviour, IDropHandler {
    [SerializeField]
    private GameObject inventory;

    private InventorySystem inventorySystem;

    private void Start() {
        inventorySystem = inventory.GetComponent<InventorySystem>();
    }
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            InventoryItemData inventoryItemData = eventData.pointerDrag.GetComponent<SlotScript>().inventoryItemData;
            inventorySystem.Remove(inventoryItemData);
        }
    }
}
