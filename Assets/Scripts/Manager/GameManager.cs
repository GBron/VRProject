using Base;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private AudioSource _audioSource;

    private void Awake()
    {
        SingletonInit();
    }

    public void PlayRadio()
    {
        _audioSource.Play();
    }
}
