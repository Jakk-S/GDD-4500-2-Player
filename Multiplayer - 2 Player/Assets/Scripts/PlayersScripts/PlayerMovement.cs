using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float moveInertia = 0.1f;
    private InputHandler _input;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _input = GetComponent<InputHandler>();
         _rb = GetComponent<Rigidbody2D>();

         //enabled = false;

         //GameManager.instance.OnStateChanged += HandleStateChanged;
    }

    // private void OnDestroy()
    // {
    //     if (GameManager.instance != null)
    //     {
    //         GameManager.instance.OnStateChanged -= HandleStateChanged;
    //     }
    // }

    // private void HandleStateChanged(GameState state)
    // {
    //     //enable script when current state is Playing
    //     enabled = (state == GameState.Playing);
    // }

    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 targetVelocity = _input.moveInput * moveSpeed;
        _rb.linearVelocity = Vector2.MoveTowards(_rb.linearVelocity, targetVelocity, moveInertia);
        _rb.linearVelocity = Vector2.ClampMagnitude(_rb.linearVelocity, moveSpeed);
    }
}
