using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Bulletを管理するクラス
/// </summary>
public class BulletManager : MonoBehaviour
{
    [Header("プール化するオブジェクトプレハブ")]
    public GameObject bullet = null;

    // Bulletクラスを登録するオブジェクトプール
    private ObjectPool<Bullet> bulletPool = null;

    //借りているオブジェクト保管用リスト
    private List<Bullet> bulletList = new List<Bullet>();

    // 補正座標
    private float offsetPosition = -10.0f;

    /// <summary>
    /// 初期化
    /// </summary>
    void Start()
    {
        // bulletプレハブのBulletクラスを取得し、100個生成
        bulletPool = new ObjectPool<Bullet>(bullet.GetComponent<Bullet>(), 100, transform);
    }

    /// <summary>
    /// 更新
    /// </summary>
    void Update()
    {
        // Fキーを押して一個出現させる
        if (Input.GetKeyDown(KeyCode.F))
        {
            // Bullet型変数objにオブジェクトプールに登録したインスタンスを代入
            Bullet obj = bulletPool.Get();

            // objのx座標をoffsetPosition分補正
            obj.transform.position = new Vector3(offsetPosition, 0.0f, 0.0f);

            // オブジェクトプールからもらったオブジェクトをリストに登録
            bulletList.Add(obj);

            // 次に表示されるobjの座標を補正
            offsetPosition += 1.0f;
        }

        // Rキーを押して一番古い弾を消す
        if (Input.GetKeyDown(KeyCode.R))
        {
            // オブジェクトプールに返却(再登録)
            bulletPool.Release(bulletList[0]);

            // リストに登録していた分を削除
            bulletList.RemoveAt(0);
        }
    }
}
