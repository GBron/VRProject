using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Base;

public class PlayerManager : Singleton<PlayerManager>
{
    public ObseravableProperty<int> Hp = new();

    private void Awake()
    {
        SingletonInit();
        Init();
    }

    private void Init()
    {
        Hp.Value = 100;
    }

    public void TakeDamage(int value)
    {
        Hp.Value -= value;

        if (Hp.Value <= 0)
        {
            // �÷��̾� ����� ��� ���� �����Ұ�
        }
    }
}
