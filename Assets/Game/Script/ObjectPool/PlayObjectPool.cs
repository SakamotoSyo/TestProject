using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// ObjectPool���������߂̃X�N���v�g
/// </summary>
public class PlayObjectPool : MonoBehaviour
{
    [Header("GameObject�𐶐����鎞��")]
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
            Debug.Log("�Ă΂ꂽ");
            ObjectPool.Instance.UseObject(new Vector2(0, 0), PoolObjectType.bullet1);
            ObjectPool.Instance.UseObject(new Vector2(0, 0), PoolObjectType.bullet2);
            ObjectPool.Instance.UseObject(new Vector2(0, 0), PoolObjectType.bullet3);

            _countTime = 0;
        }
    }
}
