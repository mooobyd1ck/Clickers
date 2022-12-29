using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneManagment : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;
    [SerializeField] GameObject _panel;
    [SerializeField] GameObject _panelTechPause;
    [SerializeField] GameObject _resumeGame;
    [SerializeField] Button _pauseButton;
    [SerializeField] Button _newGame;
    [SerializeField] Button _credits;
    [SerializeField] Button _records;
    [SerializeField] Button _exitGame;
    [SerializeField] Button _restartGame;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _enemiesScore;
    [SerializeField] private TextMeshProUGUI _loseText;

    private void Start()
    {
        Time.timeScale = 0f;
    }
    
    private void Update()
    {
        _scoreText.text = "Score: " + Spawner._updateScoreValue;
    }
    public void NewGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        _scoreText.gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(true);
        _pauseMenu.SetActive(false);
        _newGame.gameObject.SetActive(false);
        _credits.gameObject.SetActive(false);
        _records.gameObject.SetActive(false);
        _exitGame.gameObject.SetActive(false);
        _enemiesScore.gameObject.SetActive(true);
    }
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Pause()
    {
        _restartGame.gameObject.SetActive(true);
        Time.timeScale = 0f;
        _scoreText.gameObject.SetActive(false);
        _resumeGame.SetActive(true);
        _pauseMenu.SetActive(true);
        _pauseButton.gameObject.SetActive(false);
    }
    public void Credits()
    {
        _panel.SetActive(true);
        _restartGame.gameObject.SetActive(true);
    }
    public void Records()
    {
        _panelTechPause.SetActive(true);
        _restartGame.gameObject.SetActive(true);
    }
        public void ResumeGame()
         {
        SceneManager.LoadScene(1);
        _restartGame.gameObject.SetActive(false);
        _pauseButton.gameObject.SetActive(true);
        _exitGame.gameObject.SetActive(false);
        Time.timeScale = 1f;
        _scoreText.gameObject.SetActive(true);
        _resumeGame.SetActive(false);
        _pauseMenu.SetActive(false); 
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
