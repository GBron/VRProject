using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private VirPlane _virPlane;
    [SerializeField] private Material _redLamp;
    [SerializeField] private Material _greenLamp;
    [SerializeField] private MeshRenderer _meshRenderer;

    private void Update()
    {
        if (_virPlane._canBomb)
        {
            _meshRenderer.material = _greenLamp;
        }
        else
        {
            _meshRenderer.material = _redLamp;
        }
    }
}
