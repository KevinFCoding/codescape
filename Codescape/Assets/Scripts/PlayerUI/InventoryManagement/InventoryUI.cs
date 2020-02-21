using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : MonoBehaviour
{

    Inventory inventory;

    public Transform itemsParent;

    InventorySlot[] slots;

    public GameObject inventoryUI;

    public static bool InventoryUIIsActive = false;


    // Start is called before the first frame update
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallBack += UpdateUI;

        slots = itemsParent.GetComponentsInChildren<InventorySlot>();
        
    }

    private void Awake() {
        InventoryUIIsActive = false;
        }
    // Update is called once per frame
    void Update() {
        if (Input.GetButtonDown("Inventory")) {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
            InventoryUIIsActive = !InventoryUIIsActive;
            }
        }

    void UpdateUI() {

        Debug.Log("wtf");

        for (int i = 0; i < slots.Length; i++) {
            if (i < inventory.items.Count) {
                slots[i].AddItem(inventory.items[i]);
                }
            }

        }

    public static bool IsInventoryActivated() {
        return InventoryUIIsActive;
        }

}
