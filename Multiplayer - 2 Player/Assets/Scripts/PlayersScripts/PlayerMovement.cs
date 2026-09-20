using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5.0f;

    private InputHandler _input;
    private Rigidbody2D _rb;
    
    void Start()
    {
        _input = GetComponent<InputHandler>();
         _rb = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        _rb.linearVelocity = _input.moveInput * moveSpeed;
    }
}
