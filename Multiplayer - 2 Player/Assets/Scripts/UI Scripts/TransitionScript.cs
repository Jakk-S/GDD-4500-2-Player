using UnityEngine;
using DG.Tweening;
using System;
using UnityEngine.UI;

public class TransitionScript : MonoBehaviour
{
    [SerializeField] private Image transitionImage;
    private RectTransform transitionRect;

    private Vector3 _initialTransform;
    private Color imageColor;
    void Awake()
    {
        transitionRect = transitionImage.GetComponent<RectTransform>();
        _initialTransform = transitionRect.transform.localScale;
        
        imageColor =  transitionImage.color;
        imageColor.a = 0;
        transitionImage.color = imageColor;
    }
    void Start()
    {
        
    }
    public void DoTransition(Action onMidpoint = null, Action onComplete = null)
    {
        Sequence s =  DOTween.Sequence();
        s.Append(transitionImage.DOFade(1, 0.1f))
            .Join(transitionRect.DOScale(new Vector3(400, 400, 1), 0.5f).SetEase(Ease.InCubic))
            .AppendCallback(() => onMidpoint?.Invoke())
            .Append(transitionRect.DOScale(_initialTransform, 0.5f).SetEase(Ease.InCubic))
            .Append(transitionImage.DOFade(0, 0.1f))
            .OnComplete(() => onComplete?.Invoke());
            ;

    }

    public void DoEndTransition(Action onComplete = null)
    {
        imageColor.a = 1;
        transitionImage.color = imageColor;
        transitionRect.localScale = new Vector3(400, 400, 1);
        
        Sequence s =  DOTween.Sequence();
        s.Append(transitionRect.DOScale(_initialTransform, 0.5f).SetEase(Ease.InCubic))
            .Append(transitionImage.DOFade(0, 0.1f))
            .OnComplete(() => onComplete?.Invoke());
        ;
    }
}
