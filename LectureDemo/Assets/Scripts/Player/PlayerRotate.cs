using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 10f;
    [SerializeField] InputActionAsset inputActions;
    InputAction rotateAction;
    float input;

    void Start()
    {
        rotateAction = inputActions.FindAction("Look");
    }

    // Update is called once per frame
    void Update()
    {
        input = rotateAction.ReadValue<Vector2>().x;

        transform.Rotate(0, input * rotateSpeed * Time.deltaTime, 0);
    }
}
