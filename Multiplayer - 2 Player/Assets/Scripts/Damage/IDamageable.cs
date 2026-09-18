namespace Damage
{
    public interface IDamageable
    {
        void ApplyDamage(DamageInfo info);
        void ApplyHeal(float amount);
    }
}