using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
public class DeathManager : MonoBehaviour
{

    [SerializeField] private PlayerHealth player1;
    [SerializeField] private Color player1Color;
    [SerializeField] private PlayerHealth player2;
    [SerializeField] private Color player2Color;
    
    [SerializeField] private TextMeshProUGUI winText;
    
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
        winText.text = winner.name +" wins!";
        StartCoroutine(WinRoutine(loser));
    }

    IEnumerator WinRoutine(PlayerHealth loser)
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(loser.gameObject);
        Color c = winText.color;
        
        int counter = 0;
        while (counter < 10f)
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

