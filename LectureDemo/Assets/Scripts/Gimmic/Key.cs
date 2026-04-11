using UnityEngine;

public class Key : Item
{
    public override void OnPickup(GameObject player)
    {
        GameManager.Instance.AddKey();
    }
}
