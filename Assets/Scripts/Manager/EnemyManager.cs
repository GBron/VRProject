using Base;
using System.Collections;
using UnityEngine;

public class EnemyManager : Singleton<EnemyManager>
{
    [SerializeField] private Transform[] _enemySpawnPoints = new Transform[5];
    [SerializeField] private GameObject _enemyPrefab;

    private bool _canSpawn => _spawnCoroutine == null;
    private Coroutine _spawnCoroutine;
    public int EnemyCount = 0;
    private GameObject[] _enemys = new GameObject[5];

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
            if (EnemyCount >= 5) return;

            _spawnCoroutine = StartCoroutine(SpawnEnemies());
        }
    }

    IEnumerator SpawnEnemies()
    {
        // 0~4까지 랜덤 숫자 생성
        int sp = Random.Range(0, _enemySpawnPoints.Length);
        // 스폰 위치가 비어있지 않다면 적이 이미 생성되었다는 것
        if (_enemys[sp] != null)
        {
            // 해당 위치에 이미 생성되었다면 탈출 후 다시 적 생성 시도
            _spawnCoroutine = null;
            yield break;
        }

        // 숫자의 위치에 있는 Transform을 가져와서 적 생성 후 해당 위치에 적이 생성 되었음을 표시
        GameObject enemy = Instantiate(_enemyPrefab, _enemySpawnPoints[sp].position, Quaternion.identity);
        _enemys[sp] = enemy;
        EnemyCount++;
        yield return new WaitForSeconds(30f);
        _spawnCoroutine = null;
    }
}
