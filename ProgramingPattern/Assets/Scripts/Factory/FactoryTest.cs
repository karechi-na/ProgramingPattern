using UnityEngine;

/// <summary>
/// ファクトリーテストクラス
/// </summary>
public class FactoryTest : MonoBehaviour
{
    [Header("エネミーファクトリー")]
    [SerializeField] private EnemyFactory enemyFactory = null;

    // 座標移動用オフセット
    private float positionOffset = -5.0f;

    /// <summary>
    /// 更新処理
    /// </summary>
    private void Update()
    {
        // zキーを押したら丸形エネミーを生成する
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.Sphere);
            SetEnemyPosition(enemy);
        }
        // xキーを押したら立方体エネミーを生成する
        else if (Input.GetKeyDown(KeyCode.X))
        {
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.Cube);
            SetEnemyPosition(enemy);
        }
        // cキーを押したらカプセル型エネミーを生成する
        else if (Input.GetKeyDown(KeyCode.C))
        {
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.Capsule);
            SetEnemyPosition(enemy);
        }
        //　case文の例外処理確認のため追加
        else if(Input.GetKeyDown(KeyCode.V))
        {
            GameObject enemy = enemyFactory.CreateEnemy(EnemyKind.None);
        }
    }

    /// <summary>
    /// エネミーを少しずつずらして配置する
    /// </summary>
    private void SetEnemyPosition(GameObject enemy)
    {
        enemy.transform.position = new Vector3(positionOffset, 0.0f, 0.0f);
        positionOffset += 1.0f;
    }
}

// チーム制作時等で生成機能を一か所にまとめることで
// 管理しやすくかつ拡張しやすくなる。

// --- Factoryのイメージ ---
// お店に入ってコーラを飲みたいと注文した時に自分でコーラを作らず、店員が作り自分は受け取るだけ
// のようなイメージ
