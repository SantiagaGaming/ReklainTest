using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : ObjectPool
{
    [SerializeField] private GameObject[] _objPrefubs;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _secondsBetweenSpawn;
    [SerializeField] private Player _player;
    private float _elapsedTime = 0;
    private bool _canSpawn = true;
    private void Start()
    {
        Initialize(_objPrefubs);
    }
    private void Update()
    {
        if (_canSpawn) { 
        _elapsedTime += Time.deltaTime;
        if (_elapsedTime >= _secondsBetweenSpawn)
        {
            if (TryGetObject(out GameObject obj))
            {
                _elapsedTime = 0;
                int spawnPointNumber = Random.Range(0, _spawnPoints.Length);
                    SetObject(obj, _spawnPoints[spawnPointNumber].position);
            }
        }
    }
    }
    private void SetObject(GameObject obj, Vector3 spawnPoint)
    {
        obj.SetActive(true);
        obj.transform.position = spawnPoint;
    }
    private void StopSpawn()
    {
        _canSpawn = false;
    }

    private void OnEnable()
    {
        _player.EndGameEvent += StopSpawn;
    }
    private void OnDisable()
    {
        _player.EndGameEvent -= StopSpawn;
    }
}
