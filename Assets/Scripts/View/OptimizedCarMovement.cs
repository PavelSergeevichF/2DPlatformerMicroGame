using UnityEngine;

public class OptimizedCarMovement : MonoBehaviour
{
    [SerializeField]
    private float _correntSpeed = 0;
    public float CorrentSpeed => _correntSpeed;
    [SerializeField]
    private float _acseleration = 1;
    [SerializeField]
    private float _maxSpeed = 30;
    [SerializeField]
    private SimpleInputHandler2 _simpleInputHandler;

    private void Awake()
    {
        _simpleInputHandler = GetComponent<SimpleInputHandler2>();
    }
    private void Update()
    {
        _correntSpeed += _simpleInputHandler.InputHorizontal * _acseleration * Time.deltaTime;
        _correntSpeed = Mathf.Clamp(_correntSpeed, -_maxSpeed, _maxSpeed);
        transform.position += new Vector3(_correntSpeed, 0, 0);
    }
}
