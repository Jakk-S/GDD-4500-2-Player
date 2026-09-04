using UnityEngine;

public class WeaponStuff : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        transform.parent.parent.GetComponent<PlayerMovement>().ReverseRotate();
    }
}
