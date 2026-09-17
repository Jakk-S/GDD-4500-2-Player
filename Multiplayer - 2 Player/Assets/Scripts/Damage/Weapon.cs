using Damage;
using UnityEngine;
using System.Collections.Generic;
public class Weapon : MonoBehaviour
{
    [SerializeField] private WeaponData data;
    private GameObject owner;
    private HashSet<IDamageable> alreadyHit = new();

    public void SetOwner(GameObject attacker) => owner = attacker;

    public void OnCollided(Collider other)
    {
        if (other.gameObject == owner) return;
        if(!other.TryGetComponent<IDamageable>(out var target)) return;
        if (!alreadyHit.Add(target)) return;

        var info = new DamageInfo
        {
            Amount = data.baseDamage,
            Type = data.damageType,
            Source = owner,
            HitPoint = other.ClosestPoint(transform.position)
        };
        
        target.ApplyDamage(info);
    }

    public void ResetSwing() => alreadyHit.Clear();
}
