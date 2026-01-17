using UnityEngine;
using UnityEngine.Events;

public class Switch : MonoBehaviour
{
    [SerializeField] Transform plate;
    [SerializeField] float moveDepth = 0.1f;
    [SerializeField] UnityEvent onPressed,onReleased;
    float originY;
    bool isPressed = false;
    int objectCount = 0;

    void Start()
    {
        originY = plate.localPosition.y;
    }

    void Update()
    {
        if (isPressed)
        {
            if (Mathf.Abs(originY - moveDepth - plate.localPosition.y) > 0.01f)
            {
                plate.localPosition = Vector3.Lerp(plate.localPosition, new Vector3(plate.localPosition.x, originY - moveDepth, plate.localPosition.z), 0.1f);
            }
        }
        else
        {
            if (Mathf.Abs(originY - plate.localPosition.y) > 0.01f)
            {
                plate.localPosition = Vector3.Lerp(plate.localPosition, new Vector3(plate.localPosition.x, originY, plate.localPosition.z), 0.1f);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag != "Gimmic")
        {
            objectCount++;
            Debug.Log("Switch Triggered by " + other.gameObject.name);
            if (objectCount > 1) return;
            isPressed = true;
            onPressed.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag != "Gimmic")
        {
            objectCount--;
            if (objectCount > 0) return;
            isPressed = false;
            onReleased.Invoke();
        }
    }
}
