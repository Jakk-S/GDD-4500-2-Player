using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public bool CoinTaken { get; private set; }

    public void TakeCoin(string playerName)
    {
        if (CoinTaken) return;

        CoinTaken = true;

        Debug.Log($"{playerName} got the coin");
    }
}
