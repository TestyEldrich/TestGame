using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SlotScript : MonoBehaviour
{
    [SerializeField]
    private Image icon;
    [SerializeField]
    private TextMeshProUGUI label;
    [SerializeField]
    private GameObject stackObj;
    [SerializeField]
    private Text stackNumber;

    public void Set(InventoryItem item) {
        icon.sprite = item.data.icon;
        label.text = item.data.displayName;
        if(item.stackSize <= 1) {
            stackObj.SetActive(false);
            return;
        }

        stackNumber.text = item.stackSize.ToString();
    }

}
