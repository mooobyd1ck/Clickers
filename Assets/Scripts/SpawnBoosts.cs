using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBoosts : MonoBehaviour
{
    [SerializeField] private GameObject[] _arrayBoosts = new GameObject[2];
    public static bool _reloadIsGameActive = false;
    private float _currentTime = 0;
    private float _timerTime = 3;
    private void Start()
    {
        _currentTime = _timerTime;
        _reloadIsGameActive = false;
        InvokeRepeating("SpawnManagerBoosts", 1, Random.Range(15, 25));
    }
    private void Update()
    {

        StartingCoroutine();
    }
    private void SpawnManagerBoosts()
    {
        if (Spawner._isGameActive == true)
        {
            int _arrayBoostsIndex = (Random.Range(0, _arrayBoosts.Length));
            Instantiate(_arrayBoosts[_arrayBoostsIndex], GenerateSpawnPosition(), Quaternion.identity);
        }
    }
    Vector3 GenerateSpawnPosition()
    {
        float _spawnPositionX = Random.Range(-3f, 2.6f);
        float _spawnPositionY = Random.Range(0.450f, 3.6f);
        float _spawnPositionZ = Random.Range(-4.4f, 4.7f);

        Vector3 _spawnPos = new Vector3(_spawnPositionX, _spawnPositionY, _spawnPositionZ);
        return _spawnPos;
    }

    private void StartingCoroutine()
    {
        if (_reloadIsGameActive == true)
        {
            StartCoroutine(StartTimer());
        }
    }
    IEnumerator StartTimer()
    {
        //Timer for reload
        _currentTime -= 1 * Time.deltaTime;

        if (_currentTime <= 0)
        {
            Spawner._isGameActive = true;
            if (Spawner._isGameActive == true)
            {
                _currentTime = 3;
            }
            _reloadIsGameActive = false;
        }
        if (_currentTime <= 0)
        {
            yield break;
        }
    }
}
