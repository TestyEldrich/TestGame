using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    [SerializeField]
    public Image icon;
    [SerializeField]
    private TextMeshProUGUI label;
    [SerializeField]
    private GameObject stackObj;
    [SerializeField]
    private Text stackNumber;

    public InventoryItemData inventoryItemData { get; private set; }
    public InventoryItem inventoryItem { get; private set; }

    private void Start() {
        DragAndDrop dragAndDrop = transform.GetComponent<DragAndDrop>();
        dragAndDrop.canvas = transform.GetComponentInParent<Canvas>();
    }

    public void Set(InventoryItem item) {
        inventoryItemData = item.data;
        inventoryItem = item;
        icon.sprite = inventoryItem.data.icon;
        label.text = inventoryItem.data.displayName;
        if(inventoryItem.stackSize <= 1) {
            stackObj.SetActive(false);
            return;
        }

        stackNumber.text = inventoryItem.stackSize.ToString();
    }

}
