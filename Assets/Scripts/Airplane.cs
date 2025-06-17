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
        // 체력 변동 시 _hpGauge의 바늘을 회전 시켜야함
        // 현재 체력에서 최대 체력을 나눠 비율을 구한 뒤 그 비율에 mathf.lerp를 이용하여 각을 구하고 회전
        // 체력게이지의 변동각은 42도에서 -42도

        float hpPercent = PlayerManager.Instance.Hp.Value / 100f;
        float angle = Mathf.Lerp(42f, -42f, hpPercent);
        _hpGauge.transform.localRotation = Quaternion.Euler(0f, angle, 0f);
    }
}
