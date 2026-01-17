using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    Elevator elevator;

    void Start()
    {
        elevator = transform.parent.GetComponent<Elevator>();
    }

    void OnTriggerEnter(Collider other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Player" || tag == "Pushable")
        {
            other.transform.SetParent(transform.parent);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out PlayerMove player))
        {
            player.SetFloorMoveVelocity(elevator.GetVelocity());
        }
    }
    void OnTriggerExit(Collider other)
    {
        string tag = other.gameObject.tag;

        if (tag == "Player" || tag == "Pushable")
        {
            other.transform.SetParent(null);
        }
    }
}
