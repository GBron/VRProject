using Base;
using System.Collections;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private Transform[] _enemySpawnPoints = new Transform[5];
    [SerializeField] private GameObject _enemyPrefab;

    private bool _canSpawn => _spawnCoroutine == null;
    private Coroutine _spawnCoroutine;

    private void Awake()
    {
        SingletonInit();
        Init();
    }

    private void Init()
    {

    }

    private void Update()
    {
        if (_canSpawn)
        {
            _spawnCoroutine = StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        Instantiate(_enemyPrefab, _enemySpawnPoints[Random.Range(0, _enemySpawnPoints.Length)].position, Quaternion.identity);
        yield return new WaitForSeconds(20f);
        _spawnCoroutine = null;
    }
}
