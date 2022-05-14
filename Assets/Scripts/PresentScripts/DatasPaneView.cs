using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DatasPaneView : MonoBehaviour
{
    public SetItemSO[] _setItem;
    [SerializeField]
    private GameObject[] _setItemView;
    private bool _activ = false;

    void Start()
    {
        _activ =(_setItemView.Length!= _setItem.Length)? false : true;
        if(_activ)
        {
            setPanel();
        }
    }

    void Update()
    {
        
    }
    public void setPanel()
    {
        for (int i = 0; i < _setItemView.Length; i++)
        {
            if (_setItem[i].Amount < 1)
            {
                _setItemView[i].SetActive(false);
            }
            else 
            {
                _setItemView[i].SetActive(true);
                _setItemView[i].GetComponent<DataElementView>().SetItem(_setItem[i].Amount, _setItem[i].Icon);
            }
        }
    }
}
