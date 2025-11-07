using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 汎用オブジェクトプール
/// </summary>
// Component -> 基底クラス
// 基底クラスComponentを持ったものだけ扱える(制限をかける)オブジェクトプール
public class ObjectPool<T> where T : Component
{
    // 生成プレハブ
    private T prefab = null;

    // プール管理キュー
    private Queue<T> pool = new Queue<T>();

    // 生成オブジェクトをまとめる親トランスフォーム
    private Transform parent = null;

    /// <summary>
    /// コンストラクタ
    /// </summary>
    public ObjectPool(T prefab, int initialSize, Transform parent = null)
    {
        // プレハブと親を設定
        this.prefab = prefab;
        this.parent = parent;

        //初期生成
        for (int i = 0; i < initialSize; i++)
        {
            T obj = CreateNewObjet();
            pool.Enqueue(obj);
        }
    }

    /// <summary>
    /// 新規オブジェクト生成
    /// </summary>
    private T CreateNewObjet()
    {
        // オブジェクト生成
        T obj = GameObject.Instantiate(prefab, parent);
        obj.gameObject.SetActive(false);
        return obj;
    }

    /// <summary>
    /// オブジェクトを取りだす
    /// </summary>
    public T Get()
    {
        // プールにオブジェクトがあればプールから取得
        if (pool.Count > 0)
        {
            // キューから登録を外す
            T obj = pool.Dequeue();
            // アクティブに
            obj.gameObject.SetActive(true);
            return obj;
        }
        else
        {
            // 足りない場合は新しく生成する
            return CreateNewObjet();
        }
    }

    /// <summary>
    /// オブジェクトを返却する
    /// </summary>
    public void Release(T obj)
    {
        //オブジェクトを非アクティブにして再度登録する
        obj.gameObject.SetActive(false);
        pool.Enqueue(obj);
    }
}
