using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleScript : MonoBehaviour
{
    [Header("ワイヤーを出すマズル")]
    [SerializeField] Transform _muzzle;
    [Header("Rayを伸ばす最大の距離")]
    [SerializeField] float _maxDistance = 50;
    [Header("生成するばねの強さ")]
    [SerializeField] float _springPower;
    [Header("ばねの減衰速度")]
    [SerializeField] float _springDamper;
    [SerializeField] float _massScale;
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] Rigidbody _rb;
    [SerializeField] SpringJoint _springJoint;
    [SerializeField] LineRenderer _line;

    bool _isGrapple = false;
    [Tooltip("Rayが当たった座標")]
    Vector3 _rayCastHitPosition;

    void Start()
    {

    }

    void Update()
    {
        Transform camera = Camera.main.transform;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, camera.forward * _maxDistance, out hit))
        {
            if (Input.GetKeyDown(KeyCode.F) && !_playerMove.Grappleing)
            {
                //ObjectにSpringJointをつける
                _springJoint = gameObject.AddComponent<SpringJoint>();
                _rayCastHitPosition = hit.point;
                //最初は自動的にアンカーがつながる設定になっているのでOffに切り替える
                _springJoint.autoConfigureConnectedAnchor = false;
                //ワイヤーの位置を設定
                _springJoint.connectedAnchor = hit.point;
                _playerMove.Grappleing = true;

                float distanceFromPoint = Vector3.Distance(transform.position, _rayCastHitPosition);
                //ジョイントの長さを変更
                //強制的に短くする事で引っ張られる事になる
                _springJoint.maxDistance = distanceFromPoint * 0.8f;
                _springJoint.minDistance = distanceFromPoint * 0.25f;

                _springJoint.spring = _springPower;
                _springJoint.damper = _springDamper;
                _springJoint.massScale = _massScale;
                _line.positionCount = 2;
                Input.ResetInputAxes();
            }
        }

        if (Input.GetKeyDown(KeyCode.F) && _playerMove.Grappleing)
        {
            Debug.Log("解除");
            _playerMove.Grappleing = false;
            _line.positionCount = 0;
            Destroy(_springJoint);
        }

        if (_playerMove.Grappleing)
        {
            _line.SetPosition(0, _muzzle.position);
            _line.SetPosition(1, _rayCastHitPosition);
        }
    }

    void OnDrawGizmos()
    {
        
    }
}
