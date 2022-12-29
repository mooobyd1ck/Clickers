using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class UiHandler : MonoBehaviour
{
    [SerializeField] Button _pause;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _loseText;
    private void Update()
    {
        _scoreText.text = "Score: " + Spawner._updateScoreValue;
        LoseText();
    }
    public void PauseMenu()
    {
        SceneManager.LoadScene(0);  
    }
    public void LoseText()
    {
        List<GameObject> _enemies = Singleton.instance.allObjects;
        if (_enemies.Count >= 10)
        {
            Time.timeScale = 0f;
            _loseText.gameObject.SetActive(true);
        }
    }
   
}
