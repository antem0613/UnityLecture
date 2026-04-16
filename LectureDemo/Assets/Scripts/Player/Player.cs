using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    [SerializeField] float killY = -10f;
    CharacterController characterController;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (transform.position.y < killY)
        {
            Respawn();
        }
    }

    public void GetDamage()
    {
        Debug.Log("Player Get Damage");
        Respawn();
    }

    public void Respawn()
    {
        Debug.Log("Respawn Player");
        characterController.enabled = false;
        gameObject.transform.SetLocalPositionAndRotation(spawnPoint.position, spawnPoint.localRotation);
        characterController.enabled = true;
    }
}
