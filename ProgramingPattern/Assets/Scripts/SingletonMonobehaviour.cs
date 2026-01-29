using System;
using UnityEngine;

/// <summary>
/// Singleton抽象クラス
/// </summary>
// テンプレートをMonoBehaviourに制限
// where：条件を指定するときに使う
// T　　：テンプレートのT。Tと書けばテンプレートが使える
// MonoBehaviour：テンプレートで指定するクラスの条件
public abstract class SingletonMonobehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T instance;

    // getterプロパティ
    /// <summary>
    /// 呼び出し時にget内を実行
    /// </summary>
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                // タイプを取得
                Type t = typeof(T);

                // tと一致する最初のオブジェクトを返し、
                // (T)キャストしてinstanceに代入
                instance = FindFirstObjectByType<T>();

                if (instance == null)
                    Debug.Log(t + " をアタッチしているGameObjectはありません");
            }

            // returnでInstanceにinstanceを入れる
            return instance;
        }
    }

    // 派生クラスで強制ではないが、必要なら上書きできる動作を提供するためのvirtualメソッド
    virtual protected void Awake()
    {
        // ほかのGameObjectにアタッチされているか調べる
        // アタッチされている場合は破棄する。
        CheckInstance();
    }

    /// <summary>
    /// インスタンスのチェック
    /// </summary>
    protected bool CheckInstance()
    {
        // nullチェック
        if (instance == null)
        {
            // インスタンスをTキャストしてinstanceに代入
            instance = this as T;
            return true;
        }
        // Instanceが自身(インスタンス)だったら
        else if (Instance == this)
        {
            return true;
        }

        Destroy(this);
        return false;
    }
}

// static変数、関数 -> クラス依存
// それ以外の変数、関数 -> インスタンス依存

// this -> 自分のインスタンス
// static内では扱えないと思っていい

// as でのキャストは失敗するとnullが返る

// ↓ 抽象クラスについて
// abstractメソッド -> 必ず派生クラスでoverrideしなければならない
// virtualメソッド -> デフォルト実装があり、必要な時だけoverride(上書き)できる
// 通常メソッド -> overrideできない(sealedな扱い)

// 抽象クラス内のvirtualメソッド
// 基本動作をデフォルト実装しておきたい
//  -> 抽象クラスはインスタンス化されないけど、共通で使えるメソッド実装持たせたい
//　　　-> 派生クラスでは必要に応じて上書きできる
// 柔軟な拡張性を持つ

// Singleton
// 「クラスのインスタンスを必ず1つだけに制限し、どこからでも同じインスタンスにアクセスできるようにする」
// 　設計パターン
// 
// メリット
// 1. グローバルに1つだけ存在する保証
// 　　→設定値や共有状態を安全に保てる
// 　　→参照先が明確
// 
// 2. アクセスが簡単
// 　　→Factory等が不要で手軽
// 
// 3. 状態共有が容易
// 　　→ログ、キャッシュ、接続管理に向いている
// 
// デメリット
// 1. グローバル変数と同じ問題を持つ
// 　　→どこからでも触れる
// 　　→変更影響が追いにくい
// 
// 2. テストがしにくい
// 　　→状態が残りやすい
// 
// 3. 責務が肥大化しやすい
// 　　→「とりあえずSingleton」にしがち
// 　　→神クラス化の温床
// 
// 4. ライフサイクル制御が難しい
// 　　→明示的に破棄できない
// 　　→再初期化が面倒
