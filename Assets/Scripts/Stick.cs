using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Transform _grip;

    private Transform _resetPos;
    private bool _isGripped = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _resetPos = _grip;
    }

    private void Update()
    {
        if (!_isGripped)
        {
            SetZeroPos();
            return;
        }

        StickRotate();
    }

    private void StickRotate()
    {
        // 손잡이 위치에서 Stick 방향을 계산
        Vector3 gripDir = (_grip.position - transform.position).normalized;
        // Stick의 방향을 손잡이 방향으로 회전
        transform.rotation = Quaternion.LookRotation(Vector3.forward, gripDir);
    }

    public void GripStick()
    {
        _isGripped = true;
    }

    public void ReleaseStick()
    {
        _isGripped = false;
    }

    public void SetZeroPos()
    {
        // Stick을 초기 위치로 되돌림
        _grip.position = _resetPos.position;
        _grip.rotation = _resetPos.rotation;
        Vector3 gripDir = (_resetPos.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, gripDir);
    }
}
