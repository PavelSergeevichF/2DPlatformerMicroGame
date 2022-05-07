using System;
//using DV.Events;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class SimpleSpeedToText : MonoBehaviour
{
    //[SerializeField] private FlootVariable speed;
    //public SimpleCarMovement SimpleCarMovement => _simpleCarMovement;
    [SerializeField] private TextMeshProUGUI _textField;
    void Start()
    {
        _textField = GetComponent<TextMeshProUGUI>();
    }

    /*
    void Update()
    {
        _textField.text = speed?.Variabl.ToString();
    }*/
    [SerializeField] private FloatEventChannel GameAction;
    private void OnEnable()
    {
        if(GameAction != null)
        {
            GameAction.RegisterListener(UpdateText);
        }
    }
    private void OnDisable()
    {
        if (GameAction != null)
        {
            GameAction.UnregisterListener(UpdateText);
        }
    }
    public void UpdateText(float speed)
    {
        _textField.text = speed.ToString();
        Debug.Log("UpdateText");
    }
}
