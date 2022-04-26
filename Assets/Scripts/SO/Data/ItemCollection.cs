using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "ItemCollection", menuName = "ItemCollection", order = 1)]
public class ItemCollection : ScriptableObject
{
    public List<ContainInventoryItem> containInventory = new List<ContainInventoryItem>();
    public List<int> Id = new List<int>();
    public List<GameObject> itemSprite = new List<GameObject>();
}