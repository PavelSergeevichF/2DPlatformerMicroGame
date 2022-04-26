using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryView : MonoBehaviour
{
    private bool ShoweInventory = false;
    [SerializeField]
    private GameObject InventoryPanel;
    public List<GameObject> Contains;
    [SerializeField]
    private ItemCollection _itemCollection;
    private InventaryControllerMy _inventoryController;
    private InventaryModelUI _inventoryModelUI;

    public void Awake()
    {
        _inventoryController = new InventaryControllerMy(_inventoryModelUI, this, _itemCollection);
        _inventoryModelUI = new InventaryModelUI();
    }
    public void OnClicInventory()
    { 
        if(!ShoweInventory)
        {
            ShoweInventory = true;
        }
        else 
        {
            ShoweInventory = false;
        }
        InventoryPanel.SetActive(ShoweInventory);
    }
    public void Update()
    {
        _inventoryController.timerShowMessage();
    }
}
