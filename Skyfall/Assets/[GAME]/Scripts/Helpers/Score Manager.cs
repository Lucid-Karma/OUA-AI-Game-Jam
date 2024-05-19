using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Text elemaný

    private int score = 0;

    private void OnEnable()
    {
        MeteorManager.OnMeteorDestroy.AddListener(UpdateScore);
    }
    private void OnDisable()
    {
        MeteorManager.OnMeteorDestroy.RemoveListener(UpdateScore);
    }

    private void UpdateScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
