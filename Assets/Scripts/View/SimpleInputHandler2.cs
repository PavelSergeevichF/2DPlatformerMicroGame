using UnityEngine;

internal class SimpleInputHandler2 : ISimpleInputHandler
{
    public float ReturnInput()=>Input.GetAxis("Horizontal");
}