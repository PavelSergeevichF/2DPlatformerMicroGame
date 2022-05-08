
using UnityEngine;

[CreateAssetMenu(fileName = "New Vector3Variable",menuName = "Vector3Variable", order =51)]
public class Vector3Variable : ScriptableObject
{
    public Vector3 Vector3;
    public void SetVector3(Vector3 Value)
    {
        this.Vector3 = Value;
    }
}
