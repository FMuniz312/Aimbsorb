using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIEndCanvasController : MonoBehaviour
{
    [SerializeField] GameObject WinPanel;
    [SerializeField] GameObject LosePanel;
    private void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);

        GameManager.onGameLost += GameManager_onGameLost;
        GameManager.onGameWon += GameManager_onGameWon;
    }

    private void GameManager_onGameWon(object sender, System.EventArgs e)
    {
        WinPanel.SetActive(true);
    }

    private void GameManager_onGameLost(object sender, System.EventArgs e)
    {
        LosePanel.SetActive(true);
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene(0);
    }
    private void OnDestroy()
    {
        GameManager.onGameLost -= GameManager_onGameLost;
        GameManager.onGameWon -= GameManager_onGameWon;
    }
}
