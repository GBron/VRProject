using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapTrigger : MonoBehaviour
{
    // ������Ʈ �ڽ��� �̸��� ���� Ʈ���� ����
    // Ʈ���Ű� ���� ����� ��ġ �̵�

    [SerializeField] private GameObject _virPlane;

    private void OnTriggerEnter(Collider other)
    {
        // ī�޶� ����Ʈ�� Ʈ���ſ� ���� �� Ʈ������ �̸��� ���� �ݴ������� �̵���Ű��
        if (other.gameObject.layer == 11) 
        {
            if (gameObject.name == "TopT")
            {
                _virPlane.transform.position = new Vector3(_virPlane.transform.position.x, _virPlane.transform.position.y, _virPlane.transform.position.z - 0.865f);
            }
            else if (gameObject.name == "BottomT")
            {
                _virPlane.transform.position = new Vector3(_virPlane.transform.position.x, _virPlane.transform.position.y, _virPlane.transform.position.z + 0.865f);
            }
            else if (gameObject.name == "RightT")
            {
                _virPlane.transform.position = new Vector3(_virPlane.transform.position.x - 0.755f, _virPlane.transform.position.y, _virPlane.transform.position.z);
            }
            else if (gameObject.name == "LeftT")
            {
                _virPlane.transform.position = new Vector3(_virPlane.transform.position.x + 0.755f, _virPlane.transform.position.y, _virPlane.transform.position.z);
            }
        }
    }
}
