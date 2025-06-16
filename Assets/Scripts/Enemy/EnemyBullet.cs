using Base;
using System.Collections;
using UnityEngine;

public class EnemyBullet : PooledObject
{
    public Rigidbody Rigid;
    private TrailRenderer _trailRenderer;

    private void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
        _trailRenderer = GetComponent<TrailRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.layer == 3)
        {
            _trailRenderer.Clear();
            Rigid.velocity = Vector3.zero;
            ReturnPool();
        }
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
