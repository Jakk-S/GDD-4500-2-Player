using UnityEngine;

[CreateAssetMenu(menuName = "Weapon/WeaponData")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public float baseDamage;
    public DamageType damageType;
    public float rotationSpeed;
    public Vector2 rotationOffset;
    public Sprite[] weaponSprites;

}
