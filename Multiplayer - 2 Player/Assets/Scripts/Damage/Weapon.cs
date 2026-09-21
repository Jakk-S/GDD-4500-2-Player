using Damage;
using UnityEngine;
using  DG.Tweening;
using System.Collections.Generic;
public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData data;
    private GameObject owner;

    public void SetOwner(GameObject attacker) => owner = attacker;

    public float rotSpeed { get; private set; }
    public Sprite[] weaponSpr { get ; private set; }

    void Awake()
    {
        //setting rotation speed and offset from weapon data
        rotSpeed = data.rotationSpeed * 100;
        transform.localPosition = new Vector3(0, data.rotationOffset, 0);

        //Setting sprites in weapon from weapon data
        weaponSpr = new Sprite[data.weaponSprites.Length];
        int i = 0;
        foreach (var sprite in data.weaponSprites)
        {
            weaponSpr[i] = sprite;
            i++;
        }
    }
    public void OnCollided(Collision2D collision)
    {
        if (collision.gameObject == owner) return;
        if(!collision.gameObject.TryGetComponent<IDamageable>(out var target)) return;

        var info = new DamageInfo
        {
            Amount = data.baseDamage,
            Type = data.damageType,
            Source = owner,
            HitPoint = collision.GetContact(0).point
        };
        
        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 0f, 0.1f)
            .SetUpdate(true).SetLink(gameObject) 
            .OnComplete(() => DOTween.To(() => Time.timeScale, x => Time.timeScale = x, 1f, 0.3f).SetUpdate(true)).SetLink(gameObject);
        target.ApplyDamage(info);
    }
    
}
