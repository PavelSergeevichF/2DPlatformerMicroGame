using UnityEngine;
using UnityEngine.UI;

public class MessageTextUi : MonoBehaviour
{
    public static Text textInfo;
    public static void ClearMessage()
    {
        textInfo.text = "";
    }
    public static void SetMessage(string str)
    {
        textInfo.text = str;
    }
}