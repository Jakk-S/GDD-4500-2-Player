using UnityEngine;

public enum PlayerSlot
{
   Player1,
   Player2
}

public class PlayerInfo : MonoBehaviour
{
   [field: SerializeField] public PlayerSlot playerSlot { get; private set;}
}
