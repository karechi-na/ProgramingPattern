// --- Factoryのイメージ ---
// お店に入ってコーラを飲みたいと注文した時に、自分でコーラを作らず、
// 店員（Factory）が作り、自分（呼び出し側）は受け取るだけ、というイメージ。
// ※ 生成処理を専門のクラスに任せることで、コードの分離・管理がしやすくなる。

using UnityEngine;

/// <summary>
/// 敵の種類
/// </summary>
public enum EnemyKind : int
{
    None = -1,  // case文のdefault処理確認のため追加
    [Tooltip("sphereEnemy指定用")] Sphere = 0,
    [Tooltip("cubeEnemy指定用")] Cube,
    [Tooltip("capsuleEnemy指定用")] Capsule,
}

/// <summary>
/// 敵を生成する“工場（Factory）”
/// プレハブを生成する処理をこのクラスに集約することで、
/// 他のコードが「具体的に何をInstantiateするか」を知らずにすむ（疎結合）
/// </summary>
public class EnemyFactory : MonoBehaviour
{
    #region 生成対象のプレハブ参照
    [Header("丸形エネミープレハブ")]
    [SerializeField] private GameObject sphereEnemy = null;

    [Header("立方体エネミープレハブ")]
    [SerializeField] private GameObject cubeEnemy = null;

    [Header("カプセルエネミープレハブ")]
    [SerializeField] private GameObject capsuleEnemy = null;
    #endregion

    /// <summary>
    /// エネミー生成メソッド（外部が使う唯一のメソッド）
    /// EnemyKind を指定するだけで適切なプレハブが返ってくる。
    /// 呼び出し側は Instantiate の詳細を知らなくてよくなる。
    /// </summary>
    public GameObject CreateEnemy(EnemyKind kind)
    {
        // 返却用インスタンス
        GameObject enemyInstance = null;

        // エネミー別生成メソッド切り替え
        switch (kind)
        {
            // sphere生成
            case EnemyKind.Sphere: enemyInstance = CreateSphereEnemy(); break;
            // cube生成
            case EnemyKind.Cube: enemyInstance = CreateCubeEnemy(); break;
            // capsule生成
            case EnemyKind.Capsule: enemyInstance = CreateCapsuleEnemy(); break;
            // エラー時
            default:
                Debug.LogError($"CreateEnemyメソッド呼び出し時、想定外の EnemyKind.{kind} が渡されたため生成に失敗しました。");

                // LogErrorに書くものとして、エラーが起こったタイミングと変数などの原因を表示する。
                // 今回の状態だと生成処理が実行されたときEnemyKindがNoneだとエラーを吐くため、引数で受け取ったEnemyKind型変数 kind を表示すると良い。
                // 原因の引数以外にも、なにをしたときにエラーが起こったかの状況を書くと尚よい（今回で言う「CreateEnemyメソッド呼び出し時」）

                break;
        }

        return enemyInstance;
        // switch case文でreturnしない
        //　→プログラミングの作法的なものでreturnはなるべく減らそうという考えから

        // 今回はシンプルだからreturnしちゃえばいいじゃんと考えてしまうが、
        // インスタンスに格納しておくことで生成した後初期化など別の操作がほしくなったとき扱いやすくなる
        // また、作法にも則れるのでインスタンス格納が適している
    }

    //========================================================
    // 以下実際のenemy生成処理
    // 生成部分をメソッド化することで責務分離と可読性が向上
    //========================================================
    /// <summary>
    /// 丸形エネミー生成
    /// </summary>
    private GameObject CreateSphereEnemy()
    {
        return Instantiate(sphereEnemy);
    }

    /// <summary>
    /// 立方体エネミー生成
    /// </summary>
    private GameObject CreateCubeEnemy()
    {
        return Instantiate(cubeEnemy);
    }

    /// <summary>
    /// カプセル型エネミー生成
    /// </summary>
    private GameObject CreateCapsuleEnemy()
    {
        return Instantiate(capsuleEnemy);
    }
}

// PoliceCar など BaseCar を継承した車を生成したい場合、返り値は BaseCar 型にして返す。
// 受け取り側では BaseCar 型となるため、サブクラス固有の機能を使う場合は as や is でキャストして取り出す必要がある。
// ※ BaseCar を継承したクラスは、BaseCar baseCar = new PoliceCar(); のように代入可能。
