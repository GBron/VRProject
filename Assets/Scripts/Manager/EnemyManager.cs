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
        // 0~4���� ���� ���� ����
        int sp = Random.Range(0, _enemySpawnPoints.Length);
        // ���� ��ġ�� ������� �ʴٸ� ���� �̹� �����Ǿ��ٴ� ��
        if (_enemys[sp] != null)
        {
            // �ش� ��ġ�� �̹� �����Ǿ��ٸ� Ż�� �� �ٽ� �� ���� �õ�
            _spawnCoroutine = null;
            yield break;
        }

        // ������ ��ġ�� �ִ� Transform�� �����ͼ� �� ���� �� �ش� ��ġ�� ���� ���� �Ǿ����� ǥ��
        GameObject enemy = Instantiate(_enemyPrefab, _enemySpawnPoints[sp].position, Quaternion.identity);
        _enemys[sp] = enemy;
        EnemyCount++;
        yield return new WaitForSeconds(30f);
        _spawnCoroutine = null;
    }
}
