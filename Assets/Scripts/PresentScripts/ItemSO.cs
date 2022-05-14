using UnityEngine;

[CreateAssetMenu(fileName = "ItemSO", menuName = "ScriptableObjects/ItemSO", order = 1)]

public class ItemSO : ScriptableObject
{
    public int Amount;
    public Sprite Icon;
    public TipeElement TipeElement;
    public int worth;
}