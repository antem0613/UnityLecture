using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    CharacterController characterController;
    int score = 0;

    void Start()
    {
        score = 0;
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        
    }

    public void AddScore(int points)
    {
        score += points;
    }

    public int GetScore()
    {
        return score;
    }

    public void Respawn()
    {
        Debug.Log("Respawn Player");
        characterController.enabled = false;
        gameObject.transform.SetLocalPositionAndRotation(spawnPoint.position, spawnPoint.localRotation);
        characterController.enabled = true;
    }
}
