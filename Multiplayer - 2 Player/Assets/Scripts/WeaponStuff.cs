using UnityEngine;

public class WeaponStuff : MonoBehaviour
{
    [SerializeField] [Range(0, 5)] private int damage = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.parent.GetComponent<PlayerMovement>().ReverseRotate();
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerInfo>().TakeDamage(damage);
        }
    }
}
