using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectPlayer : MonoBehaviour
{
    public bool _isPlayerDetected = false;
    public GameObject Player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 3)
        {
            _isPlayerDetected = true;
            Player = other.gameObject;
            Debug.Log("Player detected!");
        }
    }
}
