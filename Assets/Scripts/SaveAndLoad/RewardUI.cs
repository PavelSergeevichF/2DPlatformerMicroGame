using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RewardUI : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI amountText;
    public RewardSO rewardSo;

    private void Start()
    {
        if(rewardSo != null)
        {
            icon.sprite = rewardSo.type.Sprite;
            amountText.text = rewardSo.amount.ToString();
        }
    }
    public void OnConsuneReward()
    {
        rewardSo.alreadyHad = true;
    }
}