using UnityEngine;

public class PanelController : MonoBehaviour
{
    // Unity Editörü'nde atanacak olan oyun içi paneli ve oyun bitiþ paneli için GameObject deðiþkenleri
    public GameObject InGamePanel;
    public GameObject GameEndPanel;

    // Oyun baþladýðýnda bitiþ ekraný deðil inGame paneli görünür olacak þekilde ayarlanýyor.
    private void Start()
    {
        GameEndPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }

    private void OnEnable()
    {
        // GameManager sýnýfýnda tanýmlý olan OnLevelFail eylemine EndGame metodunu abone ediyor
        GameManager.OnLevelFail += EndGame;
    }
    private void OnDisable()
    {
        // GameManager sýnýfýnda tanýmlý olan OnLevelFail eyleminden EndGame metodunu çýkarýyor
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
