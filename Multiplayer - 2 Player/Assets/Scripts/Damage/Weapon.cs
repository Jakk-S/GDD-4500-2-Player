using Damage;
using UnityEngine;
using  DG.Tweening;
using TMPro;
public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData data;
    private GameObject owner;
    private BoxCollider2D collider;
    public void SetOwner(GameObject attacker) => owner = attacker;

    public float rotSpeed { get; private set; }
    public Sprite[] weaponSpr { get ; private set; }

    [SerializeField] private TextMeshProUGUI dmgText;

    private int numHits = 0;

    void Awake()
    {
        collider = GetComponent<BoxCollider2D>();
        collider.enabled = false;

        if (data != null)
        {
            collider.enabled = true;
            //setting rotation speed and offset from weapon data
            rotSpeed = data.rotationSpeed;
            transform.localPosition = new Vector3(data.rotationOffset.x, data.rotationOffset.y, 0);

            //Setting sprites in weapon from weapon data
            weaponSpr = new Sprite[data.weaponSprites.Length];
            int i = 0;
            foreach (var sprite in data.weaponSprites)
            {
                weaponSpr[i] = sprite;
                i++;
            }

            dmgText.text = $"DMG: {data.baseDamage}";
        }
    }
    public void OnCollided(Collision2D collision)
    {
        if(data == null) return;
        if(!collision.gameObject.TryGetComponent<IDamageable>(out var target)) return;

        numHits++;

        var info = new DamageInfo
        {
            Amount = data.baseDamage + (data.damageChange * numHits),
            Type = data.damageType,
            Source = owner,
            HitPoint = collision.GetContact(0).point
        };

        dmgText.text = $"DMG: {data.baseDamage + (data.damageChange * numHits)}";

        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0f, 0.1f)
            .SetUpdate(true).SetLink(gameObject) 
            .OnComplete(() => DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, 0.3f).SetUpdate(true)).SetLink(gameObject);
        target.ApplyDamage(info);
    }
    
}
