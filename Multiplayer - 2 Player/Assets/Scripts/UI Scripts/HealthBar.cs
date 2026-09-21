using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth pHealth;
    public Slider healthBar;
    public Image foregroundImage;
    
    private RectTransform healthBarRect;
    private float lastHealth;
    
    private Sequence healthSeq;

    void Start()
    {
        healthBar.value = pHealth.CurrentHealth;
        lastHealth = pHealth.CurrentHealth;
        healthBarRect = healthBar.GetComponent<RectTransform>();
    }
    void Update()
    {
        float current =  pHealth.CurrentHealth;
        float delta = current - lastHealth;
        

        if (Mathf.Abs(delta) > 0.1f)
        {
            healthSeq?.Kill();
            healthSeq =  DOTween.Sequence();
            
            healthSeq.Append(healthBar.DOValue(current, 0.3f).SetEase(Ease.OutExpo))
                .Join(Camera.main.DOShakePosition(0.1f, 0.2f, 100))
                .Join(foregroundImage.DOFillAmount(current/100f, 0.3f).SetDelay(0.5f).SetEase(Ease.OutExpo))
                ;
        }
        

        lastHealth = current;
    }
}
