using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    private Controls _controls;
    private PlayerInfo info;

    private void Awake()
    {
        _controls = new Controls();
        Debug.Log($"Creating a new instance of Controls for {gameObject.name}");
        info = GetComponent<PlayerInfo>();

        _controls.bindingMask = InputBinding.MaskByGroup(info.PlayerSlot.ToString());

        _controls.Player.Move.performed += OnMovePerformed; // Connecting performed input to the OnMovePerformed function
        _controls.Player.Move.canceled += OnMoveCanceled; // Connecting canceled input to the OnMoveCanceled function
    }

    void OnEnable() => _controls.Player.Enable();
    void OnDisable() => _controls.Player.Disable();

    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        // Take value from context and shove it into another variable
        MoveInput = context.ReadValue<Vector2>();
        Debug.Log($"{gameObject.name} Move Input: {MoveInput}");
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        // Set move input variable to (0,0)
        MoveInput = Vector2.zero;
    }
}
