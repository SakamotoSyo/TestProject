using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ObjectPoolを試すためのスクリプト
/// </summary>
public class PlayObjectPool : MonoBehaviour
{
    [Header("GameObjectを生成する時間")]
    [SerializeField]float _insTime = 0;

    float _countTime;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _countTime += Time.deltaTime;

        if (_countTime >= _insTime) 
        {
            Debug.Log("呼ばれた");
            ObjectPool.Instance.UseObject(new Vector2(0, 0), PoolObjectType.bullet1);
            ObjectPool.Instance.UseObject(new Vector2(0, 0), PoolObjectType.bullet2);
            ObjectPool.Instance.UseObject(new Vector2(0, 0), PoolObjectType.bullet3);

            _countTime = 0;
        }
    }
}
