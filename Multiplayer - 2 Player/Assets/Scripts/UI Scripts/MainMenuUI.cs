using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Button playButton;

    void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton.gameObject);
    }
    void Start()
    {
        DisableMouse();
        playButton.onClick.AddListener(OnStartClicked);
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
    
    void DisableMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
