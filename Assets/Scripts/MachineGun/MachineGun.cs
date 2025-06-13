using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MachineGun : MonoBehaviour
{
    [SerializeField] Transform _grip;
    [SerializeField] Transform _visualGrip;
    [SerializeField] Transform _gun;
    [SerializeField] Transform _muzzle;
    [SerializeField] GameObject _bulletPrefab;


    private void Update()
    {
        HandleGun();
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

    public void Fire()
    {
        GameObject bullet = Instantiate(_bulletPrefab, _muzzle.position, _muzzle.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(_muzzle.forward * 100f, ForceMode.Impulse);
    }
}
