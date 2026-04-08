using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float rotateAngle = 90f, moveDistance = 1f, openSpeed;
    [SerializeField] bool isOpened, slide;
    Vector3 originPosition;
    Quaternion originRotation;

    void Start()
    {
        originPosition = transform.localPosition;
        originRotation = gameObject.transform.localRotation;
        openSpeed *= Time.deltaTime;
    }

    void Update()
    {
        if (isOpened)
        {
            if (slide)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, originPosition + transform.right * moveDistance, openSpeed);
            }
            else
            {
                gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation, Quaternion.Euler(originRotation.eulerAngles + new Vector3(0, rotateAngle, 0)), openSpeed);
            }
        }
        else
        {
            if (slide)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, originPosition, openSpeed);
            }
            else
            {
                gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation, originRotation, openSpeed);
            }
        }
    }

    public void Open()
    {
        isOpened = true;
    }

    public void Close()
    {
        isOpened = false;
    }

    public void ToggleOpen()
    {
        isOpened = !isOpened;
    }
}
