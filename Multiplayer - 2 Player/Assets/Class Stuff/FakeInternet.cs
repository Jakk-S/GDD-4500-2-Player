using System;
using System.Collections;
using UnityEngine;

public class FakeInternet : MonoBehaviour
{
    public void Send(string label, float latency, Action message)
    {
        StartCoroutine(Deliver(label, latency, message));
    }

    private IEnumerator Deliver(string label, float latency, Action message)
    {
        Debug.Log($"[INTERNET] Sending {label}");

        yield return new WaitForSeconds(latency);

        Debug.Log($"[INTERNET] Delivered {label}");

        message?.Invoke();
    }
}
