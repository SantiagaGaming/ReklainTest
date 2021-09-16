using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private Text _scoreText;
    [SerializeField] private Player _player;
    [SerializeField] private Image _timeImg;
    [SerializeField] private GameObject _endGameWindow;
    [SerializeField] private Button _againButton;
    [SerializeField] private Button _exitButton;
    private float _timer;
    private int _sceneIndex;
    private void Start()
    {
        _sceneIndex = SceneManager.GetActiveScene().buildIndex;
        _againButton.onClick.AddListener(RestartGame);
        _exitButton.onClick.AddListener(Exit);
    }
    private void OnEnable()
    {
        _player.ScoreEvent += UpdateScoreText;
        _player.EndGameEvent += ShowEndGame;
        _player.GiveTimer += SetTimer;

    }
    private void OnDisable()
    {
        _player.ScoreEvent -= UpdateScoreText;
        _player.EndGameEvent -= ShowEndGame;
        _player.GiveTimer -= SetTimer;
    }
    private void UpdateScoreText(int score)
    {
        _scoreText.text = score.ToString();
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        _timeImg.fillAmount = _timer / 100;
    }
    private void ShowEndGame()
    {
        _endGameWindow.SetActive(true);
    }
    private void RestartGame()
    {
        SceneManager.LoadScene(_sceneIndex);
    }
    private void Exit()
    {
        Application.Quit();
    }
    private void SetTimer(float timer)
    {
        _timer = timer;
    }
}

