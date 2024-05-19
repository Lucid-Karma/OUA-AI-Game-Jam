using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText; // Text elemaný

    private int score = 0;

    void Update()
    {
        // Fare sol týklandýðýnda
        if (Input.GetMouseButtonDown(0))
        {
            // Skoru artýr
            score++;
            // Skoru ekranda güncelle
            scoreText.text = "Score: " + score;
        }
    }
}
