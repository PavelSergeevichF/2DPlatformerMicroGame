using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardPopup : MonoBehaviour
{
    public GameObject PopupWindow;
    private void Awake()
    {
        if(IsNextDay())
        {
            PopupWindow.SetActive(true);
        }
    }
    bool IsNextDay() 
    {
        bool t=true;
        //DateTime.UtcNow;
        return t;
    }
}
