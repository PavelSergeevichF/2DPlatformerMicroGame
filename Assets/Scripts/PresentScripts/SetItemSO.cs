
using UnityEngine.UI;
using UnityEngine;

[CreateAssetMenu(fileName = "SetItemSO", menuName = "ScriptableObjects/SetItemSO", order = 1)]
public class SetItemSO : ScriptableObject
{
    public int Amount;
    public Sprite Icon;
    public TipeElement TipeElement;
}
