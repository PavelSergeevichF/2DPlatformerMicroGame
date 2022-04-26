using UnityEngine;
using UnityEngine.UI;

public  class ContainsView : MonoBehaviour
{
    public Text CountText;
    public ContainInventoryItem containInventoryItem;
    public int count=0;
    public bool free=true;
    public bool full = false;
    public void SetTextCount()
    {
        if(count>0)
            CountText.text = count.ToString();
        else
            CountText.text = "";
    }
}