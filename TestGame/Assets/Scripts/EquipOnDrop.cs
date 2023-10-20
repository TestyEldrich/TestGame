using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class EquipOnDrop : MonoBehaviour, IDropHandler{

    private InventoryItemData inventoryItemData;
    private GameObject equippedSlot;
    
    public void OnDrop(PointerEventData eventData) {
        if (eventData.pointerDrag != null) {
            inventoryItemData = eventData.pointerDrag.GetComponent<SlotScript>().inventoryItemData;
            if (inventoryItemData.type.Equals("weapon")) {
                if (transform.childCount > 0) {
                    foreach (Transform child in transform) {
                        GameObject.Destroy(child.gameObject);
                    }
                }
                equippedSlot = Instantiate(eventData.pointerDrag, transform);
                equippedSlot.GetComponent<RectTransform>().localScale = new Vector2(1.2f, 1.2f);
                equippedSlot.GetComponent<RectTransform>().anchoredPosition = new Vector2(50, 50);
            }
        }
    }
}
