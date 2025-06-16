using Base;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class PlayerBullet : PooledObject
{
    public Rigidbody Rigid;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }


    private void OnEnable()
    {
        StartCoroutine(Return());
    }


    IEnumerator Return()
    {
        yield return new WaitForSeconds(3f);
        _trailRenderer.Clear();
        Rigid.velocity = Vector3.zero;
        ReturnPool();
    }
}
