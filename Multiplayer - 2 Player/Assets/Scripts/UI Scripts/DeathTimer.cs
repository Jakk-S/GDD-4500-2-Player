using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
public class DeathTimer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText;
    [SerializeField] private float elapsedTime = 180;
    
    private Controls _controls;
    private bool _hasMoved;
    private bool _gameStarted;
    private float _initialTime;
    
    void Awake()
    {
        _initialTime = elapsedTime;
        _controls = new Controls();
        _controls.Player.Move.performed += HasMoved;
    }

    void Start()
    {
        enabled = false;
        GameManager.instance.OnStateChanged += HandleStateChanged;
    }

    void OnEnable()
    {
        _controls.Player.Enable();
    }

    void OnDisable()
    {
        _controls.Player.Disable();
        
    }

    void OnDestroy()
    {
        if (GameManager.instance != null)
        {
            GameManager.instance.OnStateChanged -= HandleStateChanged;
        }
        _controls.Player.Move.performed -= HasMoved;
        _controls.Dispose();
    }

    void Update()
    {
        if (_gameStarted)
        {
            elapsedTime -= Time.deltaTime;
            timeText.text = FormatTime(elapsedTime);
        }
       
    }

    void HasMoved(InputAction.CallbackContext context)
    {
        if (_gameStarted) return;
        _gameStarted = true;
    }
    
    private void HandleStateChanged(GameState state)
    {
        enabled = (state == GameState.Playing);

        if (state == GameState.Playing)
        {
            elapsedTime = _initialTime;
            _gameStarted = false;
            timeText.text = FormatTime(_initialTime);
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        int milliseconds = Mathf.FloorToInt((time * 100) % 100);
        return string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
    }
    
    
}
