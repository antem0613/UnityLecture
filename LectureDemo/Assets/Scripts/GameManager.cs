using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    int score = 0;
    int keys = 0;
    [SerializeField] int maxKeys = 3;

    void Start()
    {
        Initialize();
    }

    void Update()
    {
        
    }

    void Initialize()
    {
        score = 0;
        keys = 0;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);
    }

    public int GetScore()
    {
        return score;
    }

    public void AddKey()
    {
        keys++;
        Debug.Log("Keys: " + keys + "/" + maxKeys);
    }

    public int GetKeys()
    {
        return keys;
    }

    public bool HasEnoughKeys()
    {
        return keys >= maxKeys;
    }

    public void GameClear()
    {
        Debug.Log("Game Clear! Final Score: " + score);
    }
}
