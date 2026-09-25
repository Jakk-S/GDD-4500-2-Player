using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private Button playButton;

    [SerializeField] private TransitionScript transition;

    void OnEnable()
    {
        DisableMouse();
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(playButton.gameObject);
    }
    void Start()
    {
        transition.DoEndTransition();
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
        transition.DoTransition(onMidpoint: () =>  GameManager.instance.StartGame());
       
    }

    private void HandleStateChanged(GameState state)
    {
        menuPanel.SetActive(state == GameState.MainMenu);
    }
    
    void DisableMouse()
    {
        Cursor.visible = false;
    }
}
