using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float gravity = 9.81f;
    [SerializeField] float sprintMultiplier = 2f;
    [SerializeField] InputActionAsset inputActions;
    CharacterController characterController;
    InputAction moveAction;
    InputAction jumpAction;
    InputAction sprintAction;
    Vector2 moveInput;
    Vector3 direction, floorDir;
    float  currentUp;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        moveAction = inputActions.FindAction("Move");
        jumpAction = inputActions.FindAction("Jump");
        sprintAction = inputActions.FindAction("Sprint");
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            currentUp = 0;
        }

        moveInput = moveAction.ReadValue<Vector2>();
        direction =  transform.forward * moveInput.y + transform.right * moveInput.x;
        direction *= moveSpeed;

        if (sprintAction.IsPressed())
        {
            direction *= sprintMultiplier;
        }

        if (jumpAction.triggered && currentUp == 0)
        {
            currentUp = jumpForce;
        }

        currentUp -= gravity * Time.deltaTime;

        direction += transform.up * currentUp;

        characterController.Move(floorDir + direction * Time.deltaTime);
        floorDir = Vector3.zero;
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.tag == "PushableBox")
        {
            Rigidbody rb = hit.collider.attachedRigidbody;

            if (rb != null && !rb.isKinematic && rb.linearVelocity.y < 0.3f)
            {
                Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
                rb.AddForceAtPosition(pushDir * moveSpeed, hit.point, ForceMode.Impulse);
            }
        }
    }

    public void SetFloorMoveVelocity(Vector3 moveDir)
    {
        floorDir = moveDir;
    }
}