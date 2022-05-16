using DG.Tweening;
using UnityEngine;

public class DoTweenExampleUI : MonoBehaviour
{
    [SerializeField] private int strength = 1;
    public void Shake()
    {
        transform.DOShakeScale(2f, strength);
    }
}
