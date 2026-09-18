using UnityEngine;
using UnityEngine.InputSystem;

public class FakeClient : MonoBehaviour
{
    [Header("Individual")]
    [SerializeField] private string clientName;
    [SerializeField] private Key inputKey;

    [Header("Server")]
    [SerializeField] private FakeServer server;

    [Header("Internet")]
    [SerializeField] private FakeInternet internet;
    [SerializeField] private float latency = .5f;

    private void Update()
    {
        if (Keyboard.current == null) return;

        if (Keyboard.current[inputKey].wasPressedThisFrame)
        {
            RequestCoin(); // need to make this on the server
        }
    }

    private void RequestCoin()
    {
        Debug.Log($"[{clientName}] Requesting coin");

        internet.Send($"[{clientName}] Coin request", latency, () => server.RequestCoin(clientName));
    }
}
