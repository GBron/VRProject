using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MapTrigger : MonoBehaviour
{
    // 오브젝트 자신의 이름에 따라 트리거 감지
    // 트리거가 가상 비행기 위치 이동

    [SerializeField] private GameObject _virPlane;

    private void OnTriggerEnter(Collider other)
    {
        // 카메라 포인트가 트리거에 닿을 시 트리거의 이름에 따라 반대편으로 이동시키기
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
