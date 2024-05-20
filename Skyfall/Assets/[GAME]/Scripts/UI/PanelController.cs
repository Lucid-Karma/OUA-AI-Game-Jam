using UnityEngine;

public class PanelController : MonoBehaviour
{
    // Unity Edit�r�'nde atanacak olan oyun i�i paneli ve oyun biti� paneli i�in GameObject de�i�kenleri
    public GameObject InGamePanel;
    public GameObject GameEndPanel;

    // Oyun ba�lad���nda biti� ekran� de�il inGame paneli g�r�n�r olacak �ekilde ayarlan�yor.
    private void Start()
    {
        GameEndPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }

    private void OnEnable()
    {
        // GameManager s�n�f�nda tan�ml� olan OnLevelFail eylemine EndGame metodunu abone ediyor
        GameManager.OnLevelFail += EndGame;
    }
    private void OnDisable()
    {
        // GameManager s�n�f�nda tan�ml� olan OnLevelFail eyleminden EndGame metodunu ��kar�yor
        GameManager.OnLevelFail -= EndGame;
    }

    void EndGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        InGamePanel.SetActive(false);
        GameEndPanel.SetActive(true);
        GameManager.isGameStarted = false;
    }
}
