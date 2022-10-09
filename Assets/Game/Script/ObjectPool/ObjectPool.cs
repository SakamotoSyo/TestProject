using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//ObjectPool�Ƃ�Object���ʂ�Instantiate�܂���Destroy����ƃp�[�t�H�[�}���X�������邱�Ƃ�h�����߂̃f�U�C���p�^�[��
//�e���Q�[����vampireSurvivors�̂悤�ɑ�ʂ�Instantiate�܂���Destroy����Q�[���ł͕K�{
//�t�ɂ��܂��ʂ�Instantiate�܂���Destroy���Ȃ��Q�[���ł�Object�����炩���ߐ������Ēu���Ă����̂ɂ����������g������ObjectPool���g���K�v�͂Ȃ�

public class ObjectPool : SingletonBehaviour<ObjectPool>
{
    [SerializeField] ObjectPoolData _objectPoolData = default;

    [Tooltip("�v�[������List")]
    List<Pool> _pool = new List<Pool>();

    int _poolCountIndex = 0;

    protected override void OnAwake()
    {
        _poolCountIndex = 0;

    }

    /// <summary> �ݒ肵���I�u�W�F�N�g�̎�ށA�������v�[���ɃI�u�W�F�N�g�𐶐����Ēǉ����� </summary>
    void CreatePool()
    {
        if (_poolCountIndex >= _objectPoolData.Data.Length)
        {
            //�I�u�W�F�N�g�𐶐����I�������ċN��������߂�
            return;
        }

        //poolData�ɐݒ肵���������I�u�W�F�N�g�𐶐�����
        for (int i = 0; i < _objectPoolData.Data[_poolCountIndex].MaxCount; i++)
        {
            var obj = Instantiate(_objectPoolData.Data[_poolCountIndex].PrefabObj, this.transform);
            obj.SetActive(false);
            _pool.Add(new Pool(obj, _objectPoolData.Data[_poolCountIndex].PoolObjectType));
        }

        _poolCountIndex++;
        CreatePool();
    }

    /// <summary>
    /// �I�u�W�F�N�g���g�ɂ��Ƃ��ɌĂяo���֐�
    /// </summary>
    /// <param name="position">�I�u�W�F�N�g�̈ʒu���w�肷��</param>
    /// <param name="objectType">�I�u�W�F�N�g�̎��</param>
    /// <returns>���������I�u�W�F�N�g</returns>
    public GameObject UseObject(Vector2 position, PoolObjectType objectType) 
    {
        foreach(var pool in _pool) 
        {
            //�I�u�W�F�N�g�����݃v�[���ɓ����Ă����Ԃ���object��Type����v���Ă�����
        �@�@//�w�肵��Position��Object���ړ�������SetActive��True�ɂ���
            //Object�͖�ڂ��I������SetActive��false�ɂ��邱�Ƃł����܂킷���Ƃ��ł���
            if (pool.Object.activeSelf == false && pool.Type == objectType) 
            {
                pool.Object.SetActive(true);
                pool.Object.transform.position = position;
                return pool.Object;
            }
 
        }

        //�v�[���̒��ɊY������Type��Object���Ȃ������琶������
        var newObj = Instantiate(Array.Find(_objectPoolData.Data, x => x.PoolObjectType == objectType).PrefabObj, this.transform);
        newObj.transform.position = position;
        newObj.SetActive(true);
        _pool.Add(new Pool(newObj, objectType));

        Debug.LogWarning($"{objectType}�̃v�[���̃I�u�W�F�N�g��������Ȃ��������ߐV���ɃI�u�W�F�N�g�𐶐����܂�" +
       $"\n���̃I�u�W�F�N�g�̓v�[���̍ő�l�����Ȃ��\��������܂�" +
       $"����{objectType}�̐���{_pool.FindAll(x => x.Type == objectType).Count}�ł�");

        return newObj;

    }




}

/// <summary> �v�[������Obj��ۑ����邽�߂̍\���� </summary>
struct Pool
{
    public GameObject Object;
    public PoolObjectType Type;

    public Pool(GameObject g, PoolObjectType t)
    {
        Object = g;
        Type = t;
    }

}

public enum PoolObjectType
{
    bullet1,
    bullet2,
    bullet3,
}