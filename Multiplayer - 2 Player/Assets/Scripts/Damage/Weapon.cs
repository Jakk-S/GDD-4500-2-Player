using Damage;
using UnityEngine;
using System.Collections.Generic;
public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData data;
    private GameObject owner;
    //private HashSet<IDamageable> alreadyHit = new();

    public void SetOwner(GameObject attacker) => owner = attacker;

    public void OnCollided(Collision2D collision)
    {
        if (collision.gameObject == owner) return;
        if(!collision.gameObject.TryGetComponent<IDamageable>(out var target)) return;
        //if (!alreadyHit.Add(target)) return;

        var info = new DamageInfo
        {
            Amount = data.baseDamage,
            Type = data.damageType,
            Source = owner,
            HitPoint = collision.GetContact(0).point
        };
        
        target.ApplyDamage(info);
    }

    //public void ResetSwing() => alreadyHit.Clear();
}
