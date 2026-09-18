using UnityEngine;

public class FakeServer : MonoBehaviour
{
    public bool CoinTaken { get; private set; }

    public void RequestCoin(string playerName)
    {
        if (CoinTaken) Debug.Log($"[{playerName}] denied the coin!");
        else { CoinTaken = true; Debug.Log($"[{playerName}] awarded the coin!"); }
    }
}
