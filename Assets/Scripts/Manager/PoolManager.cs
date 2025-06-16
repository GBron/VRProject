using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class PoolManager : Singleton<PoolManager>
{
    [SerializeField] PooledObject _bulletPrefab;

    public static ObjectPool _bulletPool;

    private void Awake()
    {
        SingletonInit();
        Init();
    }

    private void Init()
    {
        _bulletPool = new ObjectPool(transform, _bulletPrefab, 100);
    }

    public PlayerBullet GetBullet()
    {
        return _bulletPool.PopPool() as PlayerBullet;
    }
}
