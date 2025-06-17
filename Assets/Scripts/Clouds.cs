using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{
    private int patternNum;

    private void Awake()
    {
        patternNum = Random.Range(1, 5);
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
                transform.Translate(Vector3.back * Time.deltaTime * 3f, Space.World);
                break;
            case 2:
                transform.Translate(Vector3.back * Time.deltaTime * 5f, Space.World);
                break;
            case 3:
                transform.Translate(Vector3.back * Time.deltaTime * 10f, Space.World);
                break;
            case 4:
                transform.Translate(Vector3.back * Time.deltaTime * 15f, Space.World);
                break;
        }
    }

    private void ResetPos()
    {
        if(transform.position.z < -300f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 150f);
        }
    }
}
