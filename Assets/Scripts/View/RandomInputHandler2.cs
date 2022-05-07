using UnityEngine;

internal class RandomInputHandler2 : ISimpleInputHandler
{
    public float ReturnInput() => Random.Range(-1f, 1f);
}
