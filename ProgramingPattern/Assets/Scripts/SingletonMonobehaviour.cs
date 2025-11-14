using System;
using UnityEngine;

/// <summary>
/// Singleton抽象クラス
/// </summary>
// テンプレートをMonoBehaviourに制限
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