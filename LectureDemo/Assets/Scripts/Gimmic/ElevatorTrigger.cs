using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    Elevator elevator;

    void Start()
    {
        elevator = transform.parent.GetComponent<Elevator>();
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.TryGetComponent(out PlayerMove player))
        {
            player.SetFloorMoveVelocity(elevator.GetVelocity());
        }
    }
}
