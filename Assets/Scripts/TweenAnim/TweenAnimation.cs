using DG.Tweening;
using UnityEngine;

public class TweenAnimation : MonoBehaviour
{
    [SerializeField] private bool move = false;
    [SerializeField] private bool rotation = false;
    [SerializeField] private bool color = false;
    [SerializeField] private Transform _second;
    [SerializeField] private int _tipeAnim = 0;
    [SerializeField] private int _time = 1;
    [SerializeField] private Material _material;
    [SerializeField] private Color _color;

    void Start()
    {
        
    }

    void Update()
    {
        animationOrder(_tipeAnim);
    }

    private void animationOrder(int getTip)
    { 
        switch(getTip)
        {
            case 0:
                {
                    if (move)
                    {
                        moveTween();
                    }
                    if (rotation)
                    {
                        rotationTween();
                    }
                    if (color)
                    {
                        colorTween();
                    }
                }
                break;
            case 1:
                {
                    transform.DOLocalMove(new Vector3(5.5f, 1, 0), _time).SetEase(Ease.InOutSine).OnComplete(()=>
                    {
                        _second.DOLocalMove(new Vector3(0, 1, 0), _time).SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
                    });
                }
                break;
        };
    }
    private void moveTween()
    {
        transform.DOLocalMove(new Vector3(0,5,0), _time).SetEase(Ease.InOutSine).SetLoops(-1,LoopType.Yoyo);
    }
    private void rotationTween()
    {
        transform.DORotate(new Vector3(0, 360, 0), _time * 0.5f, RotateMode.FastBeyond360).SetEase(Ease.InSine).SetLoops(-1,LoopType.Yoyo);
    }
    private void colorTween()
    {
        _material.DOColor(_color,_time);
    }
}
