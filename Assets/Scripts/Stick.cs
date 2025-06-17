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
        MoveVirPlane();

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
        // 스틱이 움직일때 이동 위치를 토대로 vector2를 구해 조이스틱의 움직임을 계산
        // 스틱의 초기 위치를 awake에서 저장했기에 그걸 사용하면 됨
        // + 비행기는 기본 비행속도를 가지고 y축은 감가속만 진행
        float baseSpeed = 0.01f;
        float x = _grip.position.x - _resetPos.x;
        float y = _grip.position.z - _resetPos.z;
        // 구한 두 위치를 이용해 vector2를 만들고 그 방향을 통해 가상 비행기 조작
        Vector2 leverInput = new Vector2(x, y);
        // x축은 회전
        float turnAmount = leverInput.x * 300f;
        _virPlane.transform.Rotate(0f, turnAmount * Time.deltaTime, 0f);
        // y축은 감,가속
        float moveAmount = leverInput.y * 0.5f;
        float totalSpeed = baseSpeed + Mathf.Clamp(moveAmount, -0.005f, 0.06f);
        _virPlane.transform.Translate(_virPlane.transform.forward * totalSpeed * Time.deltaTime, Space.World);
    }

    public void SetZeroPos()
    {
        // Stick을 초기 위치로 되돌림
        _grip.position = _resetPos;
        _grip.rotation = _resetRot;
        Vector3 gripDir = (_grip.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(gripDir);
    }
}
