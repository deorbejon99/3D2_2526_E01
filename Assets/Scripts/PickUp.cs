using UnityEngine;
using DG.Tweening;

public class PickUp : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Sequence s = DOTween.Sequence();

        transform.DORotate(new Vector3(0,360,0), 1f, RotateMode.LocalAxisAdd).SetLoops(-1).SetEase(Ease.Linear);
        transform.DOScale(2, .5f).SetLoops(-1, LoopType.Yoyo);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
