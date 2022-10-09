using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ObjectsPoolData")]
public class ObjectPoolData : ScriptableObject
{

    public ObjectData[] Data => _data;

    [Header("�I�u�W�F�N�g�f�[�^���i�[����z��")]
    [SerializeField] ObjectData[] _data;

    [Serializable]
    public class ObjectData
    {
        public GameObject PrefabObj => _prefabObj;
        public PoolObjectType PoolObjectType => _poolType;
        public int MaxCount => _objectMaxCount;


        [Header("�I�u�W�F�N�g�̖��O")]
        [SerializeField] string _name;

        [Header("Object��Type")]
        [SerializeField] PoolObjectType _poolType;

        [Header("�I�u�W�F�N�g��Prefab")]
        [SerializeField] GameObject _prefabObj;

        [Header("�I�u�W�F�N�g�������܂Ő������邩")]
        [SerializeField] int _objectMaxCount;
        
    }
}
