using Damage;
using UnityEngine;

public class WeaponCollision : MonoBehaviour
{
    [SerializeField] private WeaponController controller;
    [SerializeField] private string[] tags;
    
    private Weapon _weapon;

    void Start()
    {
        _weapon = GetComponent<Weapon>();
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        _weapon.OnCollided(collision);
        foreach(string tag in tags)
        {
            if (collision.gameObject.CompareTag(tag))
            {
                controller.rotateRight = !controller.rotateRight;
                controller.ChangeDirection();
            }
        }
    }
    
}
