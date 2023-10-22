using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventorySystem : MonoBehaviour
{
    public Dictionary<InventoryItemData, InventoryItem> m_itemDictionary;
    public List<InventoryItem> inventory { get; private set; }
    [Header("Events")]
    public GameEvent inventoryChanged;

    private void Awake() {
        inventory = new List<InventoryItem>();
        m_itemDictionary = new Dictionary<InventoryItemData, InventoryItem>();
    }

    public void Add(InventoryItemData referenceData) {
        if (m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            value.AddToStack();
            inventoryChanged.Raise();
        }
        else {
            InventoryItem newItem = new InventoryItem(referenceData);
            inventory.Add(newItem);
            m_itemDictionary.Add(referenceData, newItem);
            inventoryChanged.Raise();
        }
    }

    public void Remove(InventoryItemData referenceData) {
        if(m_itemDictionary.TryGetValue(referenceData, out InventoryItem value)) {
            value.RemoveFromStack();

            if (value.stackSize == 0) {
                inventory.Remove(value);
                m_itemDictionary.Remove(referenceData);
                inventoryChanged.Raise();
            }
            else {
                inventoryChanged.Raise();
            }
        }
    }
}

[System.Serializable, Inspectable]
public class InventoryItem {
    public InventoryItemData data { get; private set; }
    public int stackSize { get; private set; }

    public InventoryItem(InventoryItemData source) {
        data = source;
        AddToStack();
    }

    public void AddToStack() {
        if (data.type.Equals("ammo")) {
            stackSize += 40;
        }
        else {
            stackSize++;
        }
    }

    public void RemoveFromStack() {
        stackSize--;
    }
}
