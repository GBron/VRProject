using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private GameObject _propeller;
    [SerializeField] private Rigidbody _rigid;
    [SerializeField] private EnemyDetectPlayer _detector;
    [SerializeField] GameObject _destroyEffect;
    [SerializeField] GameObject _plane;

    private int _hp;
    private AudioSource _audioSource;
    // private bool _canFire => _fireRoutine == null;
    private bool _isFiring = false;
    private Coroutine _fireRoutine;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _hp = 30;
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9 && _hp > 0)
        {
            TakeDamage(1);
        }
    }

    private void Update()
    {
        _propeller.transform.Rotate(Vector3.forward, -10000 * Time.deltaTime);
        HandleEnemy();
    }

    private void HandleEnemy()
    {
        Move();

        if (_detector._isPlayerDetected && !_isFiring)
        {
            AttackPlayer();
        }
    }

    private void Move()
    {
        if (_detector._isPlayerDetected)
        {
            _rigid.velocity = Vector3.zero;
            return;
        }

        _rigid.velocity = transform.forward * 30f;
    }

    private void AttackPlayer()
    {
        _isFiring = true;
        _fireRoutine = StartCoroutine(FireCoroutine());
    }

    public void TakeDamage(int value)
    {
        _hp -= value;

        if (_hp <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Instantiate(_destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject, 5);
        _audioSource.Play();
        _plane.SetActive(false);
        _rigid.velocity = Vector3.zero;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 50f);
    }

    private IEnumerator FireCoroutine()
    {
        EnemyBullet bullet = PoolManager.Instance.GetEnemyBullet();
        bullet.transform.SetParent(null);
        bullet.transform.position = transform.position;
        bullet.gameObject.SetActive(true);
        bullet.Rigid.AddForce((_detector.Player.transform.position - transform.position).normalized * 150f, ForceMode.Impulse);

        yield return new WaitForSeconds(1f);

        _isFiring = false;
        _fireRoutine = null;
    }
}
