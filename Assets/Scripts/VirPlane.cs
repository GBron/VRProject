using System.Collections;
using UnityEngine;

public class VirPlane : MonoBehaviour
{
    [SerializeField] private Transform _grountPoint;
    [SerializeField] private GameObject _bombEffect;

    private Coroutine _bombDelay;
    private bool _canBomb => _bombDelay == null;

    public void Bombing()
    {
        if (_canBomb)
            _bombDelay = StartCoroutine(BombDelay());
    }

    IEnumerator BombDelay()
    {
        Vector3 bombPos = _grountPoint.position;
        yield return new WaitForSeconds(2f);
        Instantiate(_bombEffect, bombPos, Quaternion.identity);
        yield return new WaitForSeconds(3f);
        _bombDelay = null;
    }
}
