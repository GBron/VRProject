using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigClouds : MonoBehaviour
{
    private int patternNum;

    private void Awake()
    {
        patternNum = Random.Range(1, 4);
    }

    private void Update()
    {
        CloudMove();
        ResetPos();
    }

    private void CloudMove()
    {
        switch (patternNum)
        {
            case 1:
                transform.Translate(Vector3.back * Time.deltaTime * 0.1f, Space.World);
                break;
            case 2:
                transform.Translate(Vector3.back * Time.deltaTime * 0.5f, Space.World);
                break;
            case 3:
                transform.Translate(Vector3.back * Time.deltaTime * 1f, Space.World);
                break;
        }
    }

    private void ResetPos()
    {
        if (transform.position.z < -200f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 100f);
        }
    }
}
