using UnityEngine;

internal class SimpleInputHandler : MonoBehaviour
{
    [SerializeField]
    internal float InputHorizontal=0;
    private void Update()
    {
        InputHorizontal = Input.GetAxis("Horizontal");
    }
}
