using UnityEngine;

public class MeleeHitbox : MonoBehaviour
{
    [SerializeField] private Weapon weapon;

    private void OnTriggerEnter(Collider other)
    {
        weapon.OnCollided(other);
    }
}
