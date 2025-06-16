using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Transform _grip;

    private Vector3 _resetPos;
    private quaternion _resetRot;
    [SerializeField] private bool _isGripped = false;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _resetPos = _grip.position;
        _resetRot = _grip.rotation;
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
        // ������ ��ġ���� Stick ������ ���
        Vector3 gripDir = (_grip.position - transform.position).normalized;
        // Stick�� ������ ������ �������� ȸ��
        transform.rotation = Quaternion.LookRotation(gripDir);
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
        // Stick�� �ʱ� ��ġ�� �ǵ���
        _grip.position = _resetPos;
        _grip.rotation = _resetRot;
        Vector3 gripDir = (_grip.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(gripDir);
    }
}
