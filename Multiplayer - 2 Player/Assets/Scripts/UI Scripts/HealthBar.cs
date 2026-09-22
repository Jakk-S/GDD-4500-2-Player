using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class HealthBar : MonoBehaviour
{
    public PlayerHealth pHealth;
    public Slider healthBar;
    public Image foregroundImage;
    public Image IconRenderer;
    public Sprite damageSprite;
    private Sprite origSprite;
    private RectTransform healthBarRect;
    private float lastHealth;
    
    private Sequence healthSeq;

    void Start()
    {
        healthBar.value = pHealth.CurrentHealth;
        lastHealth = pHealth.CurrentHealth;
        healthBarRect = healthBar.GetComponent<RectTransform>();
        origSprite = IconRenderer.sprite;
    }
    void Update()
    {
        float current =  pHealth.CurrentHealth;
        float delta = current - lastHealth;
        

        if (Mathf.Abs(delta) > 0.1f)
        {
            IconRenderer.sprite = damageSprite;
            healthSeq?.Kill();
            healthSeq =  DOTween.Sequence();
            
            healthSeq.Append(healthBar.DOValue(current, 0.3f).SetEase(Ease.OutExpo))
                .Join(Camera.main.DOShakePosition(0.1f, 0.2f, 100))
                .Join(IconRenderer.transform.DOShakePosition(0.3f, 1f, 50))
                .AppendCallback(()=> IconRenderer.sprite = origSprite)
                .Join(foregroundImage.DOFillAmount(current/100f, 0.3f).SetDelay(0.5f).SetEase(Ease.OutExpo))
                ;
        }
        

        lastHealth = current;
    }
}
