using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] Transform _propeller;
    [SerializeField] GameObject _hpGauge;

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        PlayerManager.Instance.Hp.Subscribe(SetHp);
        SetHp(1);
    }
    private void Update()
    {
        _propeller.Rotate(Vector3.forward * -10000f * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 8 && PlayerManager.Instance.Hp.Value > 0)
        {
            PlayerManager.Instance.TakeDamage(4);
        }
    }

    private void SetHp(int value)
    {
        // ü�� ���� �� _hpGauge�� �ٴ��� ȸ�� ���Ѿ���
        // ���� ü�¿��� �ִ� ü���� ���� ������ ���� �� �� ������ mathf.lerp�� �̿��Ͽ� ���� ���ϰ� ȸ��
        // ü�°������� �������� 42������ -42��

        float hpPercent = PlayerManager.Instance.Hp.Value / 100f;
        float angle = Mathf.Lerp(42f, -42f, hpPercent);
        _hpGauge.transform.localRotation = Quaternion.Euler(0f, angle, 0f);
    }
}
