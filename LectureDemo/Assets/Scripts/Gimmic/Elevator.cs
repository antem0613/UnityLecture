using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] Vector3 relativeMoveTo;
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] bool loop;
    [SerializeField] float waitTime = 2f;
    Vector3 originPos, moveTo;
    bool inOrigin, invoked;
    bool shouldMove = false;

    void Start()
    {
        originPos = transform.localPosition;
        moveTo = originPos + relativeMoveTo;
        inOrigin = true;
        invoked = false;
    }

    void FixedUpdate()
    {
        if(!inOrigin)
        {
            shouldMove = Vector3.Distance(transform.localPosition, moveTo) > 0.01f;

            if (shouldMove)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, moveTo, moveSpeed * Time.deltaTime);
            }
            else if(loop && !invoked)
            {
                Invoke(nameof(Move), waitTime);
                invoked = true;
            }
        }
        else
        {
            shouldMove = Vector3.Distance(transform.localPosition, originPos) > 0.01f;

            if (shouldMove)
            {
                transform.localPosition = Vector3.MoveTowards(transform.localPosition, originPos, moveSpeed * Time.deltaTime);
            }
            else if(loop && !invoked)
            {
                Invoke(nameof(Move), waitTime);
                invoked = true;
            }
        }
    }

    public void Move()
    {
        inOrigin = !inOrigin;
        invoked = false;
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
