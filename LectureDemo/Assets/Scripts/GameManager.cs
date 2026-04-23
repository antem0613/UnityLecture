using UnityEngine;
using System;

public class GameManager : Singleton<GameManager>
{
    int score = 0;
    int keys = 0;
    [SerializeField] int maxKeys = 3;
    [SerializeField] GameObject GameClearPanel;

    public event EventHandler OnAddKey;

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
        GameClearPanel.SetActive(false);
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
        OnAddKey?.Invoke(this, EventArgs.Empty);
        keys++;
        Debug.Log("Keys: " + keys + "/" + maxKeys);
    }

    public int GetKeyCount()
    {
        return keys;
    }

    public bool HasEnoughKeys()
    {
        return keys >= maxKeys;
    }

    public void GameClear()
    {
        GameClearPanel.SetActive(true);
        Debug.Log("Game Clear! Final Score: " + score);
    }
}
