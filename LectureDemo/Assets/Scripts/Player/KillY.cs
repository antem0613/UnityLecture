using UnityEngine;

public class KillY : MonoBehaviour
{
    [SerializeField] float killY = -30f;
    Player player;

    void Start()
    {
        player = GetComponent<Player>();
    }

    void Update()
    {
        if(gameObject.transform.position.y < killY)
        {
            player.Respawn();
        }
    }
}
