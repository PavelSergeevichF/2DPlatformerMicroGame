using UnityEngine;

public class SimpleInputManager : MonoBehaviour
{
    public float InputHorizontal = 0;
    private void Update()
    {
        InputHorizontal = Input.GetAxis("Horizontal");
    }
}
