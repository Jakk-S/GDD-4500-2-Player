using UnityEngine;

public enum PlayerSlot { Player1, Player2 }

public class PlayerInfo : MonoBehaviour
{
    [field:SerializeField] public PlayerSlot PlayerSlot { get; private set; }

    [SerializeField] [Range(0, 100)] private int maxHealth = 100;
    public int currentHeatlh;

    private void Start()
    {
        currentHeatlh = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHeatlh -= damage;
        if (currentHeatlh <= 0)
        {
            Debug.Log("Game Over!!");
        }
    }
}
