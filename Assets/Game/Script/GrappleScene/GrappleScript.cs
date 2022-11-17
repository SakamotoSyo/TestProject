using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrappleScript : MonoBehaviour
{
    [Header("���C���[���o���}�Y��")]
    [SerializeField] Transform _muzzle;
    [Header("Ray��L�΂��ő�̋���")]
    [SerializeField] float _maxDistance = 50;
    [Header("��������΂˂̋���")]
    [SerializeField] float _springPower;
    [Header("�΂˂̌������x")]
    [SerializeField] float _springDamper;
    [SerializeField] float _massScale;
    [SerializeField] PlayerMove _playerMove;
    [SerializeField] Rigidbody _rb;
    [SerializeField] SpringJoint _springJoint;
    [SerializeField] LineRenderer _line;

    bool _isGrapple = false;
    [Tooltip("Ray�������������W")]
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
                //Object��SpringJoint������
                _springJoint = gameObject.AddComponent<SpringJoint>();
                _rayCastHitPosition = hit.point;
                //�ŏ��͎����I�ɃA���J�[���Ȃ���ݒ�ɂȂ��Ă���̂�Off�ɐ؂�ւ���
                _springJoint.autoConfigureConnectedAnchor = false;
                //���C���[�̈ʒu��ݒ�
                _springJoint.connectedAnchor = hit.point;
                _playerMove.Grappleing = true;

                float distanceFromPoint = Vector3.Distance(transform.position, _rayCastHitPosition);
                //�W���C���g�̒�����ύX
                //�����I�ɒZ�����鎖�ň��������鎖�ɂȂ�
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
            Debug.Log("����");
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
