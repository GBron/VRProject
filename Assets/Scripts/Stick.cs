using Unity.Mathematics;
using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Transform _grip;
    [SerializeField] private GameObject _virPlane;

    private Vector3 _resetPos;
    private quaternion _resetRot;
    private bool _isGripped = false;

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

        MoveVirPlane();
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

    private void MoveVirPlane()
    {
        // ��ƽ�� �����϶� �̵� ��ġ�� ���� vector2�� ���� ���̽�ƽ�� �������� ���
        // ��ƽ�� �ʱ� ��ġ�� awake���� �����߱⿡ �װ� ����ϸ� ��
        float x = _grip.position.x - _resetPos.x;
        float y = _grip.position.z - _resetPos.z;
        // ���� �� ��ġ�� �̿��� vector2�� ����� �� ������ ���� ���� ����� ����
        Vector2 leverInput = new Vector2(x, y);
        // x���� ȸ��
        float turnAmount = leverInput.x * 300f;
        _virPlane.transform.Rotate(0f, turnAmount * Time.deltaTime, 0f);
        Debug.Log("������ x���� �������� Ȯ�� : " + leverInput.x);
        // y���� ��,����
        float moveAmount = leverInput.y * 0.5f;
        _virPlane.transform.Translate(_virPlane.transform.forward * moveAmount * Time.deltaTime, Space.World);
    }

    public void SetZeroPos()
    {
        // Stick�� �ʱ� ��ġ�� �ǵ���
        _grip.position = _resetPos;
        _grip.rotation = _resetRot;
        Vector3 gripDir = (_grip.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(gripDir);
    }

    private void OnDrawGizmos()
    {
        // �׽�Ʈ�� ���� ����� ��ġ ǥ��

        Gizmos.color = Color.red;
        Gizmos.DrawLine(_virPlane.transform.position, _virPlane.transform.position + _virPlane.transform.up * -10f);
    }
}
