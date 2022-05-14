using UnityEngine;

[CreateAssetMenu (fileName = "RewardSO", menuName = "ScriptableObjects/RewardSO", order =1)]
public class RewardSO : CraftGame.SU.IItem
{
    public CraftGame.SU.IItem type;
    public int amount;
    public bool alreadyHad;
}