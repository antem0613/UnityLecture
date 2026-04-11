using UnityEngine;

public class Coin : Item
{
    [SerializeField] int scoreValue = 10;
    public override void OnPickup(GameObject player)
    {
        GameManager.Instance.AddScore(scoreValue);
    }
}
