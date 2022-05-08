using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playerstats : MonoBehaviour
{
    [SerializeField]
    private int _helth = 10;
    [SerializeField] private IntEventChannel _takeDamage;

    [SerializeField] private IntEventChannel _onDeath;
    private void OnEnable()
    {
        if (_takeDamage != null)
        {
            _takeDamage.RegisterListener(hendlerTakeDamage);
        }
    }
    private void OnDisable()
    {
        if (_takeDamage != null)
        {
            _takeDamage.UnregisterListener(hendlerTakeDamage);
        }
    }
    private void hendlerTakeDamage(int damage)
    {
        _helth -= damage;
        if (_helth< 0)
        {
            _helth = 0;
            _onDeath.RaiseEvent(0);
        }
    }
}
