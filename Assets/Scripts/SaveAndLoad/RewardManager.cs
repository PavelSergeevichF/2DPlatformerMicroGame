using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField]
    private RewardSO[] _rewards;
    public GameObject rewardPrefab;

    private void Awake()
    {
        for(int i=0; i<_rewards.Length; i++ )
        {
            if(_rewards[i]==null)
            {
                continue;
            }
            GameObject prefabInstance = Instantiate(rewardPrefab, transform);
            RewardUI rewerdUI = prefabInstance.GetComponent<RewardUI>();
            rewerdUI.rewardSo = _rewards[i];
        }
    }
}
