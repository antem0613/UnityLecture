using UnityEngine;

public class GoalDoor : Door
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && GameManager.Instance.HasEnoughKeys())
        {
            Open();
        }
    }
}
