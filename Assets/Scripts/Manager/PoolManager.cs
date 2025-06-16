using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] PooledObject _playerBulletPrefab;
    [SerializeField] PooledObject _enemyBulletPrefab;

    public static ObjectPool PlayerBulletPool;
    public static ObjectPool EnemyBulletPool;

    private void Awake()
    {
        SingletonInit();
        Init();
    }

    private void Init()
    {
        PlayerBulletPool = new ObjectPool(transform, _playerBulletPrefab, 100);
        EnemyBulletPool = new ObjectPool(transform, _enemyBulletPrefab, 50);
    }

    public PlayerBullet GetBullet()
    {
        return PlayerBulletPool.PopPool() as PlayerBullet;
    }

    public EnemyBullet GetEnemyBullet()
    {
        return EnemyBulletPool.PopPool() as EnemyBullet;
    }
}
