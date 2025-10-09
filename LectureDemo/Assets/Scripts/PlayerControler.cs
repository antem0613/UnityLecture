using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControler : MonoBehaviour
{
    public float speed = 5.0f;
    public float mouseSensitivity = 8.0f;
    public float jumpForce = 7.0f;
    Animator animator;
    InputAction moveAction, jumpAction, lookAction;
    Rigidbody rb;
    bool isGrounded;
    Vector2 move, look;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isGrounded = true;
        moveAction = InputSystem.actions["Move"];
        jumpAction = InputSystem.actions["Jump"];
        lookAction = InputSystem.actions["Look"];
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        move = moveAction.ReadValue<Vector2>();

        animator.SetFloat("x", move.x);
        animator.SetFloat("y", move.y);

        if (jumpAction.WasPressedThisFrame() && isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            animator.SetTrigger("Jump");
        }

        Vector3 movement = new Vector3(move.x, 0, move.y) * speed * Time.deltaTime;

        transform.Translate(movement);

        look = lookAction.ReadValue<Vector2>();

        transform.Rotate(0, look.x * mouseSensitivity * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
