using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "ObjectsPoolData")]
public class ObjectPoolData : ScriptableObject
{

    public ObjectData[] Data => _data;

    [Header("オブジェクトデータを格納する配列")]
    [SerializeField] ObjectData[] _data;

    [Serializable]
    public class ObjectData
    {
        public GameObject PrefabObj => _prefabObj;
        public PoolObjectType PoolObjectType => _poolType;
        public int MaxCount => _objectMaxCount;


        [Header("オブジェクトの名前")]
        [SerializeField] string _name;

        [Header("ObjectのType")]
        [SerializeField] PoolObjectType _poolType;

        [Header("オブジェクトのPrefab")]
        [SerializeField] GameObject _prefabObj;

        [Header("オブジェクトをいくつまで生成するか")]
        [SerializeField] int _objectMaxCount;
        
    }
}
