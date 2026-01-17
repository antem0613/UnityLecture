using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] float rotateAngle = 90f, moveDistance = 1f;
    [SerializeField] bool isOpened, slide;
    Vector3 originPosition;
    Quaternion originRotation;

    void Start()
    {
        originPosition = transform.localPosition;
        originRotation = gameObject.transform.localRotation;
    }

    void Update()
    {
        if (isOpened)
        {
            if (slide)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, originPosition + transform.right * moveDistance, 0.1f);
            }
            else
            {
                gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation, Quaternion.Euler(originRotation.eulerAngles + new Vector3(0, rotateAngle, 0)), 0.1f);
            }
        }
        else
        {
            if (slide)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, originPosition, 0.1f);
            }
            else
            {
                gameObject.transform.localRotation = Quaternion.Lerp(gameObject.transform.localRotation, originRotation, 0.1f);
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
