using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLevelData : MonoBehaviour
{
    [SerializeField]
    private BoolVariable[] _boolVariables;
    [SerializeField]
    private RewardSO[] _rewards;

    private void OnDestroy()
    {
        SaveLavelDatas();
    }

    private void OnApplicationPause(bool pause)
    {
        SaveLavelDatas();
    }
    private void SaveLavelDatas()
    {
        for (int i = 0; i < _rewards.Length; i++)
        {
            PlayerPrefs.SetInt(_rewards[i].name, _rewards[i].alreadyHad ? 1 : 0);
        }
        //for (int i=0; i < _boolVariables.Length; i++)
        //{
        //    PlayerPrefs.SetInt(_boolVariables[i].name, _boolVariables[i].Value ? 1 : 0);
        //}
    }
}
