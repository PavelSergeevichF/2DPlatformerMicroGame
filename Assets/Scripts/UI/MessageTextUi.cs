using UnityEngine;
using UnityEngine.UI;

public class MessageTextUi : MonoBehaviour
{
    public Text textInfo;
    private void Awake()
    {
    }
    public void ClearMessage()
    {
        textInfo.text = "";
    }
    public void SetMessage(string str)
    {
        textInfo.text = str;
    }
}