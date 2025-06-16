using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    [SerializeField] private Transform _grip;
    [SerializeField] private Transform _visualGrip;
    [SerializeField] private Transform _gun;
    [SerializeField] private Transform _muzzle;
    [SerializeField] private AudioClip _fireSound;
    [SerializeField] private AudioSource _audioSource;
    
    private Coroutine _fireRoutine;
    private bool _isFiring = false;
    private bool _canFire => _fireRoutine == null;
    private WaitForSeconds _fireWait = new WaitForSeconds(0.1f);

    private void Awake()
    {
        Init();
    }

    private void Update()
    {
        HandleGun();

        if(_isFiring && _canFire)
        {
            Fire();
        }
    }

    private void Init()
    {

    }

    private void HandleGun()
    {
        GunRotate();
    }

    private void GunRotate()
    {
        // 기관총 중심축에서 손잡이 까지 방향 계산
        Vector3 gripNorVec = (_grip.position - _gun.position).normalized;

        // 방향을 역전
        Vector3 gripRevVec = -gripNorVec;

        // 구해진 방향을 이용해 기관총을 회전
        _gun.rotation = Quaternion.LookRotation(gripRevVec);
    }

    public void ReturnGripPos()
    {
        _grip.localPosition = _visualGrip.localPosition;
        _grip.localRotation = _visualGrip.localRotation;
    }

    private void Fire()
    {
        _fireRoutine = StartCoroutine(FireCoroutine());
    }

    public void StartFire()
    {
        _isFiring = true;
    }

    public void StopFire()
    {
        _isFiring = false;
    }

    IEnumerator FireCoroutine()
    {
        PlayerBullet bullet = PoolManager.Instance.GetBullet();
        bullet.transform.SetParent(null);
        bullet.transform.position = _muzzle.position;
        bullet.transform.rotation = _muzzle.rotation;
        bullet.gameObject.SetActive(true);
        bullet.Rigid.AddForce(_muzzle.forward * 150f, ForceMode.Impulse);
        _audioSource.PlayOneShot(_fireSound);

        yield return _fireWait;

        _fireRoutine = null;
    }
}
