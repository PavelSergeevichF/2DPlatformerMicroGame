using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadLevelData : MonoBehaviour
{
    [SerializeField]
    private BoolVariable[] _boolVariables;
    [SerializeField]
    private RewardSO[] _rewards;
    private void Awake()
    {
        LoadLevelDatas();
    }
    private void LoadLevelDatas()
    {
        for (int i=0; i<_rewards.Length; i++)
        {
            if (PlayerPrefs.HasKey(_rewards[i].name))
            {
                _rewards[i].alreadyHad = (PlayerPrefs.GetInt(_rewards[i].name)==1)? true : false;
            }
        }
        for (int i = 0; i < _boolVariables.Length; i++)
        {
            if (PlayerPrefs.HasKey(_boolVariables[i].name))
            {
                _boolVariables[i].Value = (PlayerPrefs.GetInt(_rewards[i].name) == 1) ? true : false;
            }
        }
    }
}
