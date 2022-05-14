using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonsPanel : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _buttonObject;
    [SerializeField]
    private Sprite EmetyElement;
    [SerializeField]
    private ItemSO[] _listItem;
    [SerializeField]  private ItemSO[] _listItemWorth1 = new ItemSO[6];
    [SerializeField]  private ItemSO[] _listItemWorth2 = new ItemSO[3];
    [SerializeField]  private ItemSO[] _listItemWorth3 = new ItemSO[1];
    //private List<ItemSO> _listItemWorth1;
    //private List<ItemSO> _listItemWorth2;
    //private List<ItemSO> _listItemWorth3;
    private int deyNow= -1;
    private ItemSO[] presentElement = new ItemSO[7];
    [SerializeField]
    private DatasPaneView datasPaneView;
    [SerializeField]
    private TimeMy timeMy;
    [SerializeField]
    private bool[] setPresentFlag = { false, false, false, false, false, false, false};


    void Start()
    {
        setEmptyPresent();
        _sortListItem();
    }

    // Update is called once per frame
    void Update()
    {
        setPresent();
    }
    private void setPresent()
    {
        bool check=false;
        int day = (int)(timeMy._progress / 300);
        if (deyNow ==-1)
        {
            deyNow = day;
        }
        else
        {
            check = deyNow == day ? false : true;
            if(check)
            {
                deyNow = day;
            }
        }
        switch (day)
        {
            case 0:
                break;
            case 1:
                if (check)
                {
                    setPresent(_listItemWorth1, day);
                }
                break;
            case 2:
                if (check)
                {
                    setPresent(_listItemWorth1, day);
                }
                break;
            case 3:
                if (check)
                {
                    setPresent(_listItemWorth1, day);
                }
                break;
            case 4:
                if (check)
                {
                    setPresent(_listItemWorth1, day);
                }
                break;
            case 5:
                if (check)
                {
                    setPresent(_listItemWorth2, day);
                }
                break;
            case 6:
                if (check)
                {
                    setPresent(_listItemWorth2, day);
                }
                break;
            case 7:
                if (check)
                {
                    setPresent(_listItemWorth3, day);
                }
                break;
        }
    }
    private void setEmptyPresent()
    { 
        foreach(GameObject go in _buttonObject)
        {
            go.transform.GetChild(0).GetComponent<Image>().sprite = EmetyElement;
        }
    }
    private void setPresent(ItemSO[] listPrice, int day)
    {
        if (day>0)
        {
            int idPresent;
            if (listPrice.Length>1)
            {
                idPresent = Random.Range(0, listPrice.Length);
            }
            else
            {
                idPresent = 0;
            }
            _buttonObject[day - 1].transform.GetChild(0).GetComponent<Image>().sprite = listPrice[idPresent].Icon;
            setPresentFlag[day - 1] = true;
            presentElement[day - 1] = listPrice[idPresent];
        }
    }
    private void _sortListItem()
    {
        int _listItemWorth1ID = 0;
        int _listItemWorth2ID = 0;
        for (int i=0;i< _listItem.Length;i++)
        {
            if (_listItem[i].worth < 2) 
            {
                _listItemWorth1[_listItemWorth1ID] = _listItem[i];
                _listItemWorth1ID++;
                //_listItemWorth1.Add(SO);
            }
            else
            {
                if (_listItem[i].worth == 2)
                {
                    _listItemWorth2[_listItemWorth2ID] = _listItem[i];
                    _listItemWorth2ID++;
                    //_listItemWorth2.Add(SO);
                }
                else
                {
                    _listItemWorth3[0] = _listItem[i];
                    //_listItemWorth3.Add(SO);
                }
            }
        }
    }

    public void GetPresent(int day)
    {
        bool getAllPresent = true;
        day--;
        if(presentElement[day] != null)
        {
            setPresentFlag[day] = false;
            foreach(SetItemSO siGO in datasPaneView._setItem)
            {
                if(presentElement[day].TipeElement== siGO.TipeElement)
                {
                    siGO.Amount += presentElement[day].Amount;
                }
            }
            _buttonObject[day].transform.GetChild(0).GetComponent<Image>().sprite = EmetyElement;
            datasPaneView.setPanel();
            setPresentFlag[day] = false;
            presentElement[day] = null;
        }
        foreach(bool check in setPresentFlag)
        {
            if(check)
            {
                getAllPresent = false;
            }
        }
        if(getAllPresent && timeMy.FullWik)
        {
            timeMy.NewWic();
        }
    }
    public void GetPresentDay1()
    {
        int day = 1;
        GetPresent(day);
    }
    public void GetPresentDay2()
    {
        int day = 2;
        GetPresent(day);
    }
    public void GetPresentDay3()
    {
        int day = 3;
        GetPresent(day);
    }
    public void GetPresentDay4()
    {
        int day = 4;
        GetPresent(day);
    }
    public void GetPresentDay5()
    {
        int day = 5;
        GetPresent(day);
    }
    public void GetPresentDay6()
    {
        int day = 6;
        GetPresent(day);
    }
    public void GetPresentDay7()
    {
        int day = 7;
        GetPresent(day);
    }
}
