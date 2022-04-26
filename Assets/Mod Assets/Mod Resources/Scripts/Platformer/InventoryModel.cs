using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using UnityEngine;

public class InventoryModel : IInventoryModel
{
    private static readonly List<IItem> _emptyCollection = new List<IItem>();
    private readonly List<IItem> _items = new List<IItem>();
    public IReadOnlyList<IItem> SetEquippedItems()
    {
        return _items ?? _emptyCollection;
    }
    public void EquipItem(IItem item)
    {
        if(_items.Contains(item)) return;
        _items.Add(item);
    }


    public void UnequipItem(IItem item)
    {
        if (!_items.Contains(item)) return;
        _items.Remove(item);
    }
}
public interface IInventoryView
{
    event EventHandler<IItem> Selected;
    event EventHandler<IItem> Deselected;
    void Display(List<IItem> items);
}
public interface IInventoryModel
{
    IReadOnlyList<IItem> SetEquippedItems();
    void EquipItem(IItem item);
    void UnequipItem(IItem item);
}
public interface IInventoryController
{
    void ShowInventory(Action callback);
    void HideInventary();
}

public class InventaryController : MonoBehaviour, IInventoryController
{
    private readonly IInventoryModel _inventoryModel;
    private readonly IItemsRepository _itemsRepository;
    private readonly IInventoryView _inventoryWindowView;

    public InventaryController([NotNull] IInventoryModel inventoryModel, [NotNull] IItemsRepository itemsRepository, [NotNull] IInventoryView inventoryView)
    {
        _inventoryModel = inventoryModel ?? throw new ArgumentNullException(nameof(inventoryModel));
        _itemsRepository = itemsRepository ?? throw new ArgumentNullException(nameof(itemsRepository));
        _inventoryWindowView = inventoryView ?? throw new ArgumentNullException(nameof(inventoryView));
    }
    public void HideInventary()
    {
        
    }

    public void ShowInventory(Action callback)
    {
        
    }
}