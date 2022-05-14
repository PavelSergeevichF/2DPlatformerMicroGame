using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeMy : MonoBehaviour
{
    [SerializeField]
    private Image _progressImage;
    public int _progress = 0;
    private int _maxVolSec = 2100;
    public bool FullWik = false;
    void Start()
    {
        RestartProgress();
    }

    void Update()
    {
        ProgressBar();
    }
    private void ProgressBar()
    {
        float tmp = _progress;
        _progressImage.fillAmount = tmp / _maxVolSec;
        if (_progress <= _maxVolSec)
        {
            _progress++;
        }
        else 
        {
            if(!FullWik)
            {
                FullWik = true;
            }
        }
    }
    private void RestartProgress()
    {
        _progress = 0;
    }
    public void NewWic()
    {
        FullWik = false;
        RestartProgress();
    }
}
