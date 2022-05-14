using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DataElementView : MonoBehaviour
{
    public GameObject _gameObject;
    public TextMeshProUGUI _amountText;

    public void SetItem(int amount, Sprite icon)
    {
        _gameObject.GetComponent<Image>().sprite= icon;
        _amountText.text = amount.ToString();
    }
}
