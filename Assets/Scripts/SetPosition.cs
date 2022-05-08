using UnityEngine;

public class SetPosition : MonoBehaviour
{
    [SerializeField]
    private Vector3Variable _positionPlayer;
    private void Update()
    {
        _positionPlayer.Vector3 = transform.position;
    }
}