using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

//ObjectPoolとはObjectを大量にInstantiateまたはDestroyするとパーフォーマンスが落ちることを防ぐためのデザインパターン
//弾幕ゲームやvampireSurvivorsのように大量のInstantiateまたはDestroyするゲームでは必須
//逆にあまり大量のInstantiateまたはDestroyしないゲームではObjectをあらかじめ生成して置いておくのにもメモリを使うためObjectPoolを使う必要はない

public class ObjectPool : SingletonBehaviour<ObjectPool>
{
    [SerializeField] ObjectPoolData _objectPoolData = default;

    [Tooltip("プールするList")]
    List<Pool> _pool = new List<Pool>();

    int _poolCountIndex = 0;

    protected override void OnAwake()
    {
        _poolCountIndex = 0;

    }

    /// <summary> 設定したオブジェクトの種類、数だけプールにオブジェクトを生成して追加する </summary>
    void CreatePool()
    {
        if (_poolCountIndex >= _objectPoolData.Data.Length)
        {
            //オブジェクトを生成し終わったら再起処理をやめる
            return;
        }

        //poolDataに設定した数だけオブジェクトを生成する
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
    /// オブジェクトを使痛いときに呼び出す関数
    /// </summary>
    /// <param name="position">オブジェクトの位置を指定する</param>
    /// <param name="objectType">オブジェクトの種類</param>
    /// <returns>生成したオブジェクト</returns>
    public GameObject UseObject(Vector2 position, PoolObjectType objectType) 
    {
        foreach(var pool in _pool) 
        {
            //オブジェクトが現在プールに入っている状態かつobjectのTypeが一致していたら
        　　//指定したPositionにObjectを移動させてSetActiveをTrueにする
            //Objectは役目を終えたらSetActiveをfalseにすることでつかいまわすことができる
            if (pool.Object.activeSelf == false && pool.Type == objectType) 
            {
                pool.Object.SetActive(true);
                pool.Object.transform.position = position;
                return pool.Object;
            }
 
        }

        //プールの中に該当するTypeのObjectがなかったら生成する
        var newObj = Instantiate(Array.Find(_objectPoolData.Data, x => x.PoolObjectType == objectType).PrefabObj, this.transform);
        newObj.transform.position = position;
        newObj.SetActive(true);
        _pool.Add(new Pool(newObj, objectType));

        Debug.LogWarning($"{objectType}のプールのオブジェクト数が足りなかったため新たにオブジェクトを生成します" +
       $"\nこのオブジェクトはプールの最大値が少ない可能性があります" +
       $"現在{objectType}の数は{_pool.FindAll(x => x.Type == objectType).Count}です");

        return newObj;

    }




}

/// <summary> プールするObjを保存するための構造体 </summary>
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