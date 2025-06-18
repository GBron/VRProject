using UnityEngine;
using System.Collections;

public class Airport : MonoBehaviour
{
    [SerializeField] private GameObject _targetMarker;
    [SerializeField] private GameObject _destroyMarker;

    private Coroutine _radioCoroutine;
    private bool _isDestroyed = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 13 && !_isDestroyed)
        {
            _destroyMarker.SetActive(true);
            _targetMarker.SetActive(false);
            _isDestroyed = true;
            if (_radioCoroutine == null)
            {
                _radioCoroutine = StartCoroutine(RadioDelay());
            }
        }
    }

    IEnumerator RadioDelay()
    {
        yield return new WaitForSeconds(0.5f);
        GameManager.Instance.PlayRadio();
        _radioCoroutine = null;
    }
}
