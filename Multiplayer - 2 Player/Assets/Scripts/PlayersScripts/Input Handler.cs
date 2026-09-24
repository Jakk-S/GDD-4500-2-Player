using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class InputHandler : MonoBehaviour
{
    public Vector2 moveInput { get; private set; }

    private Controls _controls;
    private PlayerInfo _playerInfo;

    [SerializeField] DeathManager dm;

    private void Awake()
    {
        _controls = new Controls();
        _playerInfo = GetComponent<PlayerInfo>();
        _controls.bindingMask = InputBinding.MaskByGroup(_playerInfo.playerSlot.ToString());
        
        _controls.Player.Move.performed += OnMovePerformed;
        _controls.Player.Move.canceled += OnMoveCanceled;

        _controls.Player.Reset.performed += OnResetPerformed;
    }

    void OnEnable() => _controls.Player.Enable();
    void OnDisable() => _controls.Player.Disable();

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveInput = Vector2.zero;
    }

    private void OnResetPerformed(InputAction.CallbackContext context)
    {
        Debug.Log("RESET ATTEMPTED");
        if (dm.gameOver) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
