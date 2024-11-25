using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    private Inventory inventory;
    public GameObject inventoryUI;
    public Transform ItemsParent;
    private InventorySlot[] slots;
    void Start()
    {
        inventory = Inventory.instance;
        inventory.OnItemChangedCallback += UpdateUI;

        slots = ItemsParent.GetComponentsInChildren<InventorySlot>();
    }

    
    void Update()
    {
        if (Input.GetButtonDown("inventory"))
        {
            inventoryUI.SetActive(!inventoryUI.activeSelf);
        }
    }

    void UpdateUI()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (i < inventory.items.Count)
            {
                slots[i].addItem(inventory.items[i]);
                Debug.Log("updating UI");
            }
            else
            {
                {
                    slots[i].ClearSlot();
                }
            }
        }
    }
}
