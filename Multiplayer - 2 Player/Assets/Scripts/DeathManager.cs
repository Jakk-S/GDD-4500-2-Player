using TMPro;
using UnityEngine;
using System.Collections;
public class DeathManager : MonoBehaviour
{

    [SerializeField] private PlayerHealth player1;
    [SerializeField] private Color player1Color;
    [SerializeField] private PlayerHealth player2;
    [SerializeField] private Color player2Color;
    
    [SerializeField] private TextMeshProUGUI winText;

    public bool gameOver { get; private set; }
    
    void OnEnable()
    {
        player1.OnDeath += OnPlayerOneDeath;
        player2.OnDeath += OnPlayerTwoDeath;
    }


    void OnDisable()
    {
        player1.OnDeath -= OnPlayerOneDeath;
        player2.OnDeath -= OnPlayerTwoDeath;
    }


    void OnPlayerOneDeath()
    {
        winText.color = player2Color;
        HandleDeath(player1, player2);
    }

    void OnPlayerTwoDeath()
    {
        winText.color = player1Color;
        HandleDeath(player2, player1);
    }

    private void HandleDeath(PlayerHealth loser, PlayerHealth winner)
    {
        Destroy(loser.gameObject);
        winText.text = winner.name +" wins!\nTo reset: Press R";

        gameOver = true;

        StartCoroutine(WinAnim());
    }

    IEnumerator WinAnim()
    {
        Color c = winText.color;
        while (true)
        {
            c.a = 1;
            winText.color = c;
            yield return  new WaitForSeconds(0.5f);
            c.a = 0;
            winText.color = c;
            yield return new WaitForSeconds(0.5f);
        }
    }
    
}

