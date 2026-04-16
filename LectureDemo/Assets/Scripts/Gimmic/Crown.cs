using UnityEngine;

public class Crown : Item
{
    public override void OnPickup(GameObject player){
        GameManager.Instance.GameClear();
    }
}
