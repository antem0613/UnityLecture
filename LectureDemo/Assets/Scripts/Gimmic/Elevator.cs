using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Vector3 relativeMoveTo;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] bool autoBack, loop;
    [SerializeField] float waitTime = 2f;
    Vector3 originPos, moveTo;
    bool inOrigin;
    bool shouldMove = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        originPos = transform.localPosition;
        moveTo = originPos + relativeMoveTo;
        inOrigin = true;

        if (loop)
        {
            autoBack = false;
            shouldMove = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!inOrigin && shouldMove)
        {
            shouldMove = Vector3.Distance(transform.localPosition, moveTo) > 0.01f;

            if (shouldMove)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, moveTo, moveSpeed * Time.deltaTime);
            }
            else if(autoBack || loop)
            {
                Invoke(nameof(Move), waitTime);
            }
        }
        else if(shouldMove)
        {
            shouldMove = Vector3.Distance(transform.localPosition, originPos) > 0.01f;

            if (shouldMove)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, originPos, moveSpeed * Time.deltaTime);
            }
            else if(loop)
            {
                Invoke(nameof(Move), waitTime);
            }
        }
    }

    public void Move()
    {
        Debug.Log("isOrigin: " + inOrigin);
        inOrigin = !inOrigin;
        shouldMove = true;
    }

    public Vector3 GetVelocity()
    {
        Vector3 dir = (inOrigin) ? -relativeMoveTo : relativeMoveTo;

        if (!shouldMove)
        {
            dir = Vector3.zero;
        }

        return dir.normalized * moveSpeed * Time.deltaTime;
    }
}
