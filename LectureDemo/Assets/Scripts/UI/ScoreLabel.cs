using UnityEngine;
using TMPro;

public class ScoreLabel : MonoBehaviour
{
    TMP_Text scoreText;

    void Start()
    {
        scoreText = GetComponent<TMP_Text>();
    }

    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.GetScore();
    }
}
