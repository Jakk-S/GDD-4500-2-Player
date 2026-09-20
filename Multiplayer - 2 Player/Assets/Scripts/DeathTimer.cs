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

    void OnEnable()
    {
        _controls.Player.Enable();
    }

    void OnDisable()
    {
        _controls.Player.Disable();
    }

    void Awake()
    {
        _controls = new Controls();
        _controls.Player.Move.performed += HasMoved;
    }
    void Update()
    {
        if (_gameStarted)
        {
            elapsedTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            int milliseconds = Mathf.FloorToInt((elapsedTime * 100) % 100);
            timeText.text = string.Format("{0:00}:{1:00}:{2:00}", minutes, seconds, milliseconds);
        }
       
    }

    void HasMoved(InputAction.CallbackContext context)
    {
        if (_gameStarted) return;
        _gameStarted = true;
    }
    
    
}
