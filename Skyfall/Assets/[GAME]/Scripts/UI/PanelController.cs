using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelController : MonoBehaviour
{
    public GameObject InGamePanel;
    public GameObject GameEndPanel;

    private void Start()
    {
        GameEndPanel.SetActive(false);
        InGamePanel.SetActive(true);
    }

    private void OnEnable()
    {
        GameManager.OnLevelFail += EndGame;
    }
    private void OnDisable()
    {
        GameManager.OnLevelFail -= EndGame;
    }

    void EndGame()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        InGamePanel.SetActive(false);
        GameEndPanel.SetActive(true);
        GameManager.isGameStarted = false;
        //Time.timeScale = 0.1f;
        Debug.Log("level end");
    }
}
