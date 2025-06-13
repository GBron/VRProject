using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Airplane : MonoBehaviour
{
    [SerializeField] Transform _propeller;

    private void Update()
    {
        _propeller.Rotate(Vector3.forward * -10000f * Time.deltaTime);
    }
}
