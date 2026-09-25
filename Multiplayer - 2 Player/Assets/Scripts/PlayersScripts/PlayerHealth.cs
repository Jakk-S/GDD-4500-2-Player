using Damage;
using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour, IDamageable
{
    [SerializeField] public float maxHealth =  100f; 
    public float CurrentHealth { get; private set; }

    //[SerializeField] private ArmorProfile armor;
    
    public event Action<float,float> OnHealthChanged;
    public event Action<DamageInfo> OnDamaged;
    public event Action OnDeath;

    private bool isDead;
    
    void Awake()=> CurrentHealth = maxHealth;
    

    public void ApplyDamage(DamageInfo info)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - info.Amount);
        OnDamaged?.Invoke(info);
        OnHealthChanged?.Invoke(CurrentHealth, maxHealth);
        
        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    public void ApplyHeal(float amount)
    {
        if (isDead) return;

        CurrentHealth = Mathf.Min(maxHealth, CurrentHealth + amount);
        OnHealthChanged?.Invoke(CurrentHealth, maxHealth);
    }

    private void Die()
    {
        isDead = true;
        OnDeath?.Invoke();
    }
    
}
