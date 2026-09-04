using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotateSpeed = 5f;

    private InputHandler input;
    private Rigidbody2D rb;
    private GameObject weaponAxis;

    private int rotateR = 1;

    void Start()
    {
        input = GetComponent<InputHandler>();
        rb = GetComponent<Rigidbody2D>();
        weaponAxis = transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        MovePlayer();
        weaponAxis.transform.Rotate(Vector3.forward * rotateSpeed * rotateR);
    }

    private void MovePlayer()
    {
        rb.linearVelocity = moveSpeed * input.MoveInput;
    }

    public void ReverseRotate()
    {
        rotateR *= -1;
    }
}
