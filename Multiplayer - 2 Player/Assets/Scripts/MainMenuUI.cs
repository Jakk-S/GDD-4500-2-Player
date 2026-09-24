using UnityEngine;
using UnityEngine.UI;
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Button startButton;

    void Start()
    {
        startButton.onClick.AddListener(OnStartClicked);
        GameManager.instance.OnStateChanged += HandleStateChanged;
    }

    void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnStateChanged -= HandleStateChanged;
        }
    }

    private void OnStartClicked()
    {
        GameManager.instance.StartGame();
    }

    private void HandleStateChanged(GameState state)
    {
        menuPanel.SetActive(state == GameState.MainMenu);
    }
}
