using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    // Oyundaki mevcut skoru gösteren Text UI elemaný
    public Text scoreText;

    // Yüksek skoru gösteren Text UI elemaný
    public Text highScoreText;

    // Mevcut skor deðiþkeni
    private int score = 0;

    // Yüksek skor deðiþkeni
    private int highScore = 0;

    private void Start()
    {
        // Oyunun baþladýðýnda PlayerPrefs'ten yüksek skoru al ve ekranda göster
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "High Score: " + highScore;
    }

    private void OnEnable()
    {
        // MeteorManager'dan MeteorDestroy eventini dinle
        MeteorManager.OnMeteorDestroy.AddListener(UpdateScore);
    }

    private void OnDisable()
    {
        MeteorManager.OnMeteorDestroy.RemoveListener(UpdateScore);
    }

    private void UpdateScore()
    {
        // Meteor yok edildiðinde skoru artýr
        score++;
        scoreText.text = "Score: " + score;

        // Yüksek skoru güncelle ve kaydet
        if (score > highScore)
        {
            highScore = score;
            highScoreText.text = "High Score: " + highScore;
            PlayerPrefs.SetInt("HighScore", highScore); // Yüksek skoru kaydet
        }
    }
}
