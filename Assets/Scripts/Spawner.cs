using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using Unity.VisualScripting;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] _arrayEnemies = new GameObject[3];
    [SerializeField] private float _firstDotRangeSpawn = 3;
    [SerializeField] private float _secondDotRangeSpawn = 5;
    public static float _enemySpeed = 2;
    public static float _fullHp = 10;
    public static bool _isGameActive = true;
    public static int _updateScoreValue;

    void Start()
    {
        _isGameActive = true;
     InvokeRepeating("SpawnManager", 1 , Random.Range(_firstDotRangeSpawn, _secondDotRangeSpawn));
    }
  
    void Update()
    {
        StartCoroutine(IncreaseDifficultyCoroutine());
    }
    public void SpawnManager()
    {
        if (_isGameActive == true)
        {
            SpawnEnemy(gameObject);
        }
    }
    public void SpawnEnemy(GameObject obj)
    {
        int _arrayEnemiesIndex = (Random.Range(0, _arrayEnemies.Length));
        obj = Instantiate(_arrayEnemies[_arrayEnemiesIndex], GenerateSpawnPosition(), _arrayEnemies[_arrayEnemiesIndex].transform.rotation);
        obj.AddComponent<SingletonAdd>();
    }
    //Точка спавна врагов
    Vector3 GenerateSpawnPosition()
    {
        float _spawnPositionX = Random.Range(-3f, 2.6f);
        float _spawnPositionY = Random.Range(0.450f, 3.6f);
        float _spawnPositionZ = Random.Range(-4.4f, 4.7f);

        Vector3 _spawnPos = new Vector3(_spawnPositionX, _spawnPositionY, _spawnPositionZ);
        return _spawnPos;

    }
    IEnumerator IncreaseDifficultyCoroutine()
    {
        if(_updateScoreValue >= 5 && _fullHp == 10)
        {
            _enemySpeed += 0.5f;
            _fullHp += 5;
            _firstDotRangeSpawn = 2;
            _secondDotRangeSpawn = 3;
        }
        if(_updateScoreValue >= 10 && _fullHp == 15)
        {
            _enemySpeed += 1f;
            _fullHp += 5;
            _firstDotRangeSpawn = 3;
            _secondDotRangeSpawn = 5;
        }
        if (_updateScoreValue >= 15 && _fullHp == 20)
        {
            _fullHp += 5;
            _enemySpeed += 1f;
            _firstDotRangeSpawn = 3;
            _secondDotRangeSpawn = 4;
        }
        if (_updateScoreValue >= 20 && _fullHp == 20)
        {
            _enemySpeed += 1f;
            _fullHp += 5;
            _firstDotRangeSpawn = 2;
            _secondDotRangeSpawn = 4;
        }
        yield break;
    }
   
}