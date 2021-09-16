using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    public event UnityAction<int> ScoreEvent;
    public event UnityAction<float> GiveTimer;
    public event UnityAction EndGameEvent;
    private int _score;
    private float _timer = 100;
    private void Start()
    {
        GiveTimer.Invoke(_timer);
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0) 
        {
            EndGame();
        }
    }
    public void RecountScore(int count)
    {
        _score += count;
        ScoreEvent.Invoke(_score);
    }
    private void EndGame()
    {
        EndGameEvent.Invoke();
    }
}
