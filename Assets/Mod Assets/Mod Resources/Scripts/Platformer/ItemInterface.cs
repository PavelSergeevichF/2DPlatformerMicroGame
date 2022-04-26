using UnityEngine;

public class ItemInterface : MonoBehaviour
{

}
public interface IItem
{
    int Id { get; }
}

public struct ItemInfo
{
    public string Title { get; set; }
}

public interface IItemsRepository
{
    System.Collections.Generic.IReadOnlyDictionary<int, IItem> Items { get; }
}
