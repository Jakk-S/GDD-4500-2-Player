using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using DG.Tweening;
public class ButtonFeedback : MonoBehaviour, ISelectHandler,  IDeselectHandler, ISubmitHandler
{
    private Vector3 punchPos;
    private RectTransform rectTransform;

    void Start()
    { 
       punchPos = new Vector3(4f, -4f, 0);
        rectTransform = GetComponent<RectTransform>();       
    }
    public void OnSelect(BaseEventData eventData)
    {
        Sequence s = DOTween.Sequence();
        s.Append(rectTransform.DOPunchPosition(punchPos, 0.2f))
            ;
        
    }

    public void OnDeselect(BaseEventData eventData)
    {
       
    }

    public void OnSubmit(BaseEventData eventData)
    {
        
    }
}
