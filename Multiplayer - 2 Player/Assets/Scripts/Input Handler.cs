using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandler : MonoBehaviour
{
    private Controls _controls;

    private void Awake()
    {
        _controls = new Controls();
        Debug.Log($"Creating a new instance of Controls for {gameObject.name}");

        _controls.Player.Move.performed += OnMovePerformed;
        _controls.Player.Move.canceled += OnMoveCanceled;
    }

    void OnEnable() => _controls.Enable();
    void OnDisable() => _controls.Disable();

    private void OnMovePerformed(InputAction.CallbackContext context)
    {

    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {

    }
}
