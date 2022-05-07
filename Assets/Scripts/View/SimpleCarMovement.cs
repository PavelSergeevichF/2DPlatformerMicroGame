using UnityEngine;

public class SimpleCarMovement : MonoBehaviour
{
    [SerializeField]
    private float _currentSpeed;
    public float CurrentSpeed => _currentSpeed;

    private float _acseleration = 1;
    [SerializeField]
    private float _maxSpeed = 30;

    private void Update()
    {
        float input = Input.GetAxis("Horizontal");
        _currentSpeed += input * _acseleration * Time.deltaTime;
        _currentSpeed = Mathf.Clamp(_currentSpeed, _maxSpeed, _maxSpeed);
        transform.position += new Vector3(_currentSpeed, 0, 0);
    }
}
